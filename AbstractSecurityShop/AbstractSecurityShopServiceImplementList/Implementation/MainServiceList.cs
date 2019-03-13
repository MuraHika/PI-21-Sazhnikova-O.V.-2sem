using AbstractSecurityServiceImplement;
using AbstractSecurityShopModel;
using AbstractSecurityShopServiceDAL.BindingModel;
using AbstractSecurityShopServiceDAL.Interface;
using AbstractSecurityShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceImplementList.Implementation
{
    public class MainServiceList : IMainService
    {
        private DataListSingleton source;

        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<OrderViewModel> GetList()
        {
            List<OrderViewModel> result = source.Orders.Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                CustomerId = rec.CustomerId,
                TechnicsId = rec.TechnicsId,
                DateCreate = rec.DateCreate.ToLongDateString(),
                DateImplement = rec.DateImplement?.ToLongDateString(),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                CustomerFIO = source.Customers.FirstOrDefault(recC => recC.Id ==
                rec.CustomerId)?.CustomerFIO,
                TechnicsName = source.Technics.FirstOrDefault(recP => recP.Id ==
               rec.TechnicsId)?.TechnicsName,
            }).ToList();
            return result;
        }

        public void AcceptedOrder(OrderBindingModel model)
        {
            int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
            source.Orders.Add(new Order
            {
                Id = maxId + 1,
                CustomerId = model.CustomerId,
                TechnicsId = model.TechnicsId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Accepted
            });
        }

        public void Processed(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Accepted)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            // смотрим по количеству компонентов на складах
            var technicEquipments = source.TechnicsEquipment.Where(rec => rec.TechnicsId == element.TechnicsId);
            foreach (var technicEquipment in technicEquipments)
            {
                int countOnStorage = source.StorageEquipments
                .Where(rec => rec.EquipmentId == technicEquipment.EquipmentId)
               .Sum(rec => rec.Count);
                if (countOnStorage < technicEquipment.Count * element.Count)
                {
                    var EquipmentName = source.Equipments.FirstOrDefault(rec => rec.Id ==
                   technicEquipment.EquipmentId);
                    throw new Exception("Не достаточно оборудования " +
                   EquipmentName?.EquipmentName + " требуется " + (technicEquipment.Count * element.Count) +
                   ", в наличии " + countOnStorage);
                }
            }
            // списываем
            foreach (var technicEquipment in technicEquipments)
            {
                int countOnStorages = technicEquipment.Count * element.Count;
                var storageEquipments = source.StorageEquipments.Where(rec => rec.EquipmentId
               == technicEquipment.EquipmentId);
                foreach (var storageEquipment in storageEquipments)
                {
                    // компонентов на одном слкаде может не хватать
                    if (storageEquipment.Count >= countOnStorages)
                    {
                        storageEquipment.Count -= countOnStorages;
                        break;
                    }
                    else
                    {
                        countOnStorages -= storageEquipment.Count;
                        storageEquipment.Count = 0;
                    }
                }
            }
            element.DateImplement = DateTime.Now;
            element.Status = OrderStatus.Processed;
        }

        public void OrderReady(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Processed)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = OrderStatus.Ready;
        }

        public void OrderPaid(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Ready)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = OrderStatus.Paid;
        }

        public void PutEquipmentOnStorage(StorageEquipmentBindingModel model)
        {
            StorageEquipment element = source.StorageEquipments.FirstOrDefault(rec => rec.StorageId == model.StorageId && rec.EquipmentId == model.EquipmentId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                int maxId = source.StorageEquipments.Count > 0 ? source.StorageEquipments.Max(rec => rec.Id) : 0;
                source.StorageEquipments.Add(new StorageEquipment
                {
                    Id = ++maxId,
                    StorageId = model.StorageId,
                    EquipmentId = model.EquipmentId,
                    Count = model.Count
                });
            }
        }
    }
}
