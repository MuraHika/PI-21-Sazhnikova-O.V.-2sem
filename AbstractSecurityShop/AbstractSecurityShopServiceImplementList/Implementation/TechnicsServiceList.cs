using AbstractSecurityShopServiceDAL.ViewModel;
using AbstractSecurityShopServiceDAL.Interface;
using AbstractSecurityShopServiceDAL.BindingModel;
using AbstractSecurityShopModel;
using AbstractSecurityServiceImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceImplementList.Implementation
{
    public class TechnicsServiceList : ITechnicsService
    {
        private DataListSingleton source;

        public TechnicsServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<TechnicsViewModel> GetList()
        {
            List<TechnicsViewModel> result = source.Technics.Select(rec => new TechnicsViewModel
            {
                Id = rec.Id,
                TechnicsName = rec.TechnicsName,
                Price = rec.Price,
                TechnicsEquipment = source.TechnicsEquipment.Where(recPC => recPC.TechnicsId == rec.Id).Select(recPC => new TechnicsEquipmentViewModel
                {
                    Id = recPC.Id,
                    TechnicsId = recPC.TechnicsId,
                    EquipmentId = recPC.EquipmentId,
                    EquipmentName = source.Equipments.FirstOrDefault(recC =>
                    recC.Id == recPC.EquipmentId)?.EquipmentName,
                    Count = recPC.Count
                }).ToList()
            }).ToList();
            return result;
        }

        public TechnicsViewModel GetElement(int id)
        {
            Technics element = source.Technics.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new TechnicsViewModel
                {
                    Id = element.Id,
                    TechnicsName = element.TechnicsName,
                    Price = element.Price,
                    TechnicsEquipment = source.TechnicsEquipment.Where(recPC => recPC.TechnicsId == element.Id).Select(recPC => new TechnicsEquipmentViewModel
                    {
                        Id = recPC.Id,
                        TechnicsId = recPC.TechnicsId,
                        EquipmentId = recPC.EquipmentId,
                        EquipmentName = source.Equipments.FirstOrDefault(recC => recC.Id == recPC.EquipmentId)?.EquipmentName,
                        Count = recPC.Count
                    }).ToList()
                };
            }
            throw new Exception("Техника не найдена");
        }

        public void AddElement(TechnicsBindingModel model)
        {
            Technics element = source.Technics.FirstOrDefault(rec => rec.TechnicsName == model.TechnicsName);
            if (element != null)
            {
                throw new Exception("Уже есть техника с таким названием");
            }
            int maxId = source.Technics.Count > 0 ? source.Technics.Max(rec => rec.Id) : 0;
            source.Technics.Add(new Technics
            {
                Id = maxId + 1,
                TechnicsName = model.TechnicsName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = source.TechnicsEquipment.Count > 0 ? source.TechnicsEquipment.Max(rec => rec.Id) : 0;
            // убираем дубли по компонентам
            var groupEquipments = model.TechnicsEquipment.GroupBy(rec => rec.EquipmentId).Select(rec => new
            {
                EquipmentId = rec.Key,
                Count = rec.Sum(r => r.Count)
            });
            // добавляем компоненты
            foreach (var groupEquipment in groupEquipments)
            {
                source.TechnicsEquipment.Add(new TechnicsEquipment
                {
                    Id = ++maxPCId,
                    TechnicsId = maxId + 1,
                    EquipmentId = groupEquipment.EquipmentId,
                    Count = groupEquipment.Count
                });
            }
        }

        public void UpdElement(TechnicsBindingModel model)
        {
            Technics element = source.Technics.FirstOrDefault(rec => rec.TechnicsName == model.TechnicsName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть техника с таким названием");
            }
            element = source.Technics.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Техника не найдена");
            }
            element.TechnicsName = model.TechnicsName;
            element.Price = model.Price;
            int maxPCId = source.TechnicsEquipment.Count > 0 ? source.TechnicsEquipment.Max(rec => rec.Id) : 0;
            // обновляем существуюущие компоненты
            var compIds = model.TechnicsEquipment.Select(rec => rec.EquipmentId).Distinct();
            var updateEquipments = source.TechnicsEquipment.Where(rec => rec.TechnicsId == model.Id && compIds.Contains(rec.EquipmentId));
            foreach (var updateEquipment in updateEquipments)
            {
                updateEquipment.Count = model.TechnicsEquipment.FirstOrDefault(rec =>
               rec.Id == updateEquipment.Id).Count;
            }
            source.TechnicsEquipment.RemoveAll(rec => rec.TechnicsId == model.Id && !compIds.Contains(rec.EquipmentId));
            // новые записи
            var groupEquipments = model.TechnicsEquipment.Where(rec => rec.Id == 0).GroupBy(rec => rec.EquipmentId).Select(rec => new
            {
                EquipmentId = rec.Key,
                Count = rec.Sum(r => r.Count)
            });
            foreach (var groupEquipment in groupEquipments)
            {
                TechnicsEquipment elementPC = source.TechnicsEquipment.FirstOrDefault(rec => rec.TechnicsId == model.Id && rec.EquipmentId == groupEquipment.EquipmentId);
                if (elementPC != null)
                {
                    elementPC.Count += groupEquipment.Count;
                }
                else
                {
                    source.TechnicsEquipment.Add(new TechnicsEquipment
                    {
                        Id = ++maxPCId,
                        TechnicsId = model.Id,
                        EquipmentId = groupEquipment.EquipmentId,
                        Count = groupEquipment.Count
                    });
                }
            }
        }

        public void DelElement(int id)
        {
            Technics element = source.Technics.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // удаяем записи по компонентам при удалении изделия
                source.TechnicsEquipment.RemoveAll(rec => rec.TechnicsId == id);
                source.Technics.Remove(element);
            }
            else
            {
                throw new Exception("Техника не найдена");
            }
        }
    }
}
