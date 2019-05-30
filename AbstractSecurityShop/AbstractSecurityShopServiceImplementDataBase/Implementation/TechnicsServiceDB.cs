using AbstractSecurityShopModel;
using AbstractSecurityShopServiceDAL.BindingModel;
using AbstractSecurityShopServiceDAL.Interface;
using AbstractSecurityShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceImplementDataBase.Implementation
{
    public class TechnicsServiceDB : ITechnicsService
    {
        private AbstractSecurityShopDbContext context;

        public TechnicsServiceDB(AbstractSecurityShopDbContext context)
        {
            this.context = context;
        }
        public List<TechnicsViewModel> GetList()
        {
            List<TechnicsViewModel> result = context.Technics.Select(rec => new TechnicsViewModel
            {
                Id = rec.Id,
                TechnicsName = rec.TechnicsName,
                Price = rec.Price,
                TechnicsEquipment = context.TechnicsEquipments.Where(recPC => recPC.TechnicsId == rec.Id).Select(recPC => new TechnicsEquipmentViewModel
                {
                    Id = recPC.Id,
                    TechnicsId = recPC.TechnicsId,
                    EquipmentId = recPC.EquipmentId,
                    EquipmentName = recPC.Equipment.EquipmentName,
                    Count = recPC.Count
                }).ToList()
            }).ToList();
            return result;
        }

        public TechnicsViewModel GetElement(int id)
        {
            Technics element = context.Technics.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new TechnicsViewModel
                {
                    Id = element.Id,
                    TechnicsName = element.TechnicsName,
                    Price = element.Price,
                    TechnicsEquipment = context.TechnicsEquipments.Where(recPC => recPC.TechnicsId == element.Id).Select(recPC => new TechnicsEquipmentViewModel
                    {
                        Id = recPC.Id,
                        TechnicsId = recPC.TechnicsId,
                        EquipmentId = recPC.EquipmentId,
                        EquipmentName = recPC.Equipment.EquipmentName,
                        Count = recPC.Count
                    }).ToList()
                };
            }
            throw new Exception("Техника не найдена");
        }

        public void AddElement(TechnicsBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Technics element = context.Technics.FirstOrDefault(rec => rec.TechnicsName == model.TechnicsName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть техника с таким названием");
                    }
                    element = new Technics
                    {
                        TechnicsName = model.TechnicsName,
                        Price = model.Price
                    };
                    context.Technics.Add(element);
                    context.SaveChanges();
                    // убираем дубли по компонентам
                    var groupEquipments = model.TechnicsEquipment.GroupBy(rec => rec.EquipmentId).Select(rec => new
                    {
                        EquipmentId = rec.Key,
                        Count = rec.Sum(r => r.Count)
                    });
                    // добавляем компоненты
                    foreach (var groupEquipment in groupEquipments)
                    {
                        context.TechnicsEquipments.Add(new TechnicsEquipment
                        {
                            TechnicsId = element.Id,
                            EquipmentId = groupEquipment.EquipmentId,
                            Count = groupEquipment.Count
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void UpdElement(TechnicsBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Technics element = context.Technics.FirstOrDefault(rec => rec.TechnicsName == model.TechnicsName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть техника с таким названием");
                    }
                    element = context.Technics.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Техника не найдена");
                    }
                    element.TechnicsName = model.TechnicsName;
                    element.Price = model.Price;
                    context.SaveChanges();
                    // обновляем существуюущие компоненты
                    var compIds = model.TechnicsEquipment.Select(rec => rec.EquipmentId).Distinct();
                    var updateEquipments = context.TechnicsEquipments.Where(rec => rec.TechnicsId == model.Id && compIds.Contains(rec.EquipmentId));
                    foreach (var updateEquipment in updateEquipments)
                    {
                        updateEquipment.Count = model.TechnicsEquipment.FirstOrDefault(rec => rec.Id == updateEquipment.Id).Count;
                    }
                    context.SaveChanges();
                    context.TechnicsEquipments.RemoveRange(context.TechnicsEquipments.Where(rec => rec.TechnicsId == model.Id && !compIds.Contains(rec.EquipmentId)));
                    context.SaveChanges();
                    // новые записи
                    var groupEquipments = model.TechnicsEquipment.Where(rec => rec.Id == 0).GroupBy(rec => rec.EquipmentId).Select(rec => new
                    {
                        EquipmentId = rec.Key,
                        Count = rec.Sum(r => r.Count)
                    });
                    foreach (var groupEquipment in groupEquipments)
                    {
                        TechnicsEquipment elementPC = context.TechnicsEquipments.FirstOrDefault(rec => rec.TechnicsId == model.Id && rec.EquipmentId == groupEquipment.EquipmentId);
                        if (elementPC != null)
                        {
                            elementPC.Count += groupEquipment.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.TechnicsEquipments.Add(new TechnicsEquipment
                            {
                                TechnicsId = model.Id,
                                EquipmentId = groupEquipment.EquipmentId,
                                Count = groupEquipment.Count
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Technics element = context.Technics.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.TechnicsEquipments.RemoveRange(context.TechnicsEquipments.Where(rec =>
                        rec.TechnicsId == id));
                        context.Technics.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Техника не найдена");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
