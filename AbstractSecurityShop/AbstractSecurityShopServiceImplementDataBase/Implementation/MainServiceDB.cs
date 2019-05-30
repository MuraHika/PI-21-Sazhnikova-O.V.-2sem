using AbstractSecurityShopModel;
using AbstractSecurityShopServiceDAL.BindingModel;
using AbstractSecurityShopServiceDAL.Interface;
using AbstractSecurityShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace AbstractSecurityShopServiceImplementDataBase.Implementation
{
    public class MainServiceDB : IMainService
    {
        private AbstractSecurityShopDbContext context;

        public MainServiceDB(AbstractSecurityShopDbContext context)
        {
            this.context = context;
        }

        public List<OrderViewModel> GetList()
        {
            List<OrderViewModel> result = context.Orders.Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                CustomerId = rec.CustomerId,
                TechnicsId = rec.TechnicsId,
                WorkerId = rec.WorkerId,
                DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " + SqlFunctions.DateName("mm", rec.DateCreate) + " " + SqlFunctions.DateName("yyyy", rec.DateCreate),
                DateImplement = rec.DateImplement == null ? "" : SqlFunctions.DateName("dd", rec.DateImplement.Value) + " " + SqlFunctions.DateName("mm", rec.DateImplement.Value) + " " + SqlFunctions.DateName("yyyy", rec.DateImplement.Value),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                CustomerFIO = rec.Customer.CustomerFIO,
                TechnicsName = rec.Technics.TechnicsName,
                WorkerName = rec.Worker.WorkerFIO
            }).ToList();
            return result;
        }

        public void AcceptedOrder(OrderBindingModel model)
        {
            var order = new Order
            {
                CustomerId = model.CustomerId,
                TechnicsId = model.TechnicsId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Accepted
            };
            context.Orders.Add(order);
            context.SaveChanges();
            var client = context.Customers.FirstOrDefault(x => x.Id == model.CustomerId);
            SendEmail(client.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от {1} создан успешно", order.Id, order.DateCreate.ToShortDateString()));
        }

        public void Processed(OrderBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                try
                {
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    if (element.Status != OrderStatus.Accepted && element.Status != OrderStatus.NotEnoughRes)
                    {
                        throw new Exception("Заказ не в статусе \"Принят\"");
                    }
                    var TechnicsEquipments = context.TechnicsEquipments.Include(rec => rec.Equipment).Where(rec => rec.TechnicsId == element.TechnicsId);
                    // списываем
                    foreach (var TechnicsEquipment in TechnicsEquipments)
                    {
                        int countOnStorages = TechnicsEquipment.Count * element.Count;
                        var StorageEquipments = context.StorageEquipments.Where(rec => rec.EquipmentId == TechnicsEquipment.EquipmentId);
                        foreach (var StorageEquipment in StorageEquipments)
                        {
                            // компонентов на одном слкаде может не хватать
                            if (StorageEquipment.Count >= countOnStorages)
                            {
                                StorageEquipment.Count -= countOnStorages;
                                countOnStorages = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnStorages -= StorageEquipment.Count;
                                StorageEquipment.Count = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countOnStorages > 0)
                        {
                            throw new Exception("Не достаточно компонента " + TechnicsEquipment.Equipment.EquipmentName + " требуется " + TechnicsEquipment.Count + ", не хватает " + countOnStorages);
                        }
                    }
                    element.WorkerId = model.WorkerId;
                    element.DateImplement = DateTime.Now;
                    element.Status = OrderStatus.Processed;
                    context.SaveChanges();
                    SendEmail(element.Customer.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от {1} передеан в работу", element.Id, element.DateCreate.ToShortDateString()));
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    element.Status = OrderStatus.Processed;
                    context.SaveChanges();
                    transaction.Commit();
                    throw;
                }
            }
        }

        public void OrderReady(OrderBindingModel model)
        {
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Processed)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = OrderStatus.Ready;
            context.SaveChanges();
            SendEmail(element.Customer.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от {1} передан на оплату", element.Id, element.DateCreate.ToShortDateString()));
        }

        public void OrderPaid(OrderBindingModel model)
        {
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Ready)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = OrderStatus.Paid;
            context.SaveChanges();
            SendEmail(element.Customer.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от {1} оплачен успешно", element.Id, element.DateCreate.ToShortDateString()));
        }

        public void PutEquipmentOnStorage(StorageEquipmentBindingModel model)
        {
            StorageEquipment element = context.StorageEquipments.FirstOrDefault(rec => rec.StorageId == model.StorageId && rec.EquipmentId == model.EquipmentId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.StorageEquipments.Add(new StorageEquipment
                {
                    StorageId = model.StorageId,
                    EquipmentId = model.EquipmentId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }

        public List<OrderViewModel> GetFreeOrders()
        {
            List<OrderViewModel> result = context.Orders.Where(x => x.Status == OrderStatus.Accepted || x.Status == OrderStatus.NotEnoughRes).Select(rec => new OrderViewModel
            {
                Id = rec.Id
            }).ToList();
            return result;
        }

        private void SendEmail(string mailAddress, string subject, string text)
        {
            MailMessage objMailMessage = new MailMessage();
            SmtpClient objSmtpClient = null;
            try
            {
                objMailMessage.From = new
               MailAddress(ConfigurationManager.AppSettings["MailLogin"]);
                objMailMessage.To.Add(new MailAddress(mailAddress));
                objMailMessage.Subject = subject;
                objMailMessage.Body = text;
                objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                objSmtpClient = new SmtpClient("smtp.gmail.com", 587);
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.EnableSsl = true;
                objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                objSmtpClient.Credentials = new
               NetworkCredential(ConfigurationManager.AppSettings["MailLogin"],
               ConfigurationManager.AppSettings["MailPassword"]);
                objSmtpClient.Send(objMailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMailMessage = null;
                objSmtpClient = null;
            }
        }
    }
}
