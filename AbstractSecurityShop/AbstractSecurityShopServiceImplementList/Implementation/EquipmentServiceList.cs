using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractSecurityServiceImplement;
using AbstractSecurityShopModel;
using AbstractSecurityShopServiceDAL.BindingModel;
using AbstractSecurityShopServiceDAL.Interface;
using AbstractSecurityShopServiceDAL.ViewModel;

namespace AbstractSecurityShopServiceImplementList.Implementation
{
    public class EquipmentServiceList : IEquipmentService
    {
        private DataListSingleton source;

        public EquipmentServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<EquipmentViewModel> GetList()
        {
            List<EquipmentViewModel> result = source.Equipments.Select(rec => new EquipmentViewModel
            {
                Id = rec.Id,
                EquipmentName = rec.EquipmentName
            }).ToList();
            return result;
        }

        public EquipmentViewModel GetElement(int id)
        {
            Equipment element = source.Equipments.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new EquipmentViewModel
                {
                    Id = element.Id,
                    EquipmentName = element.EquipmentName
                };
            }
            throw new Exception("Оборудование не найдено");
        }

        public void AddElement(EquipmentBindingModel model)
        {
            Equipment element = source.Equipments.FirstOrDefault(rec => rec.EquipmentName == model.EquipmentName);
            if (element != null)
            {
                throw new Exception("Уже есть оборудование с таким названием");
            }
            int maxId = source.Equipments.Count > 0 ? source.Equipments.Max(rec => rec.Id) : 0;
            source.Equipments.Add(new Equipment
            {
                Id = maxId + 1,
                EquipmentName = model.EquipmentName
            });
        }

        public void UpdElement(EquipmentBindingModel model)
        {
            Equipment element = source.Equipments.FirstOrDefault(rec => rec.EquipmentName == model.EquipmentName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть оборудование с таким названием");
            }
            element = source.Equipments.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Оборудование не найдено");

            }
            element.EquipmentName = model.EquipmentName;
        }

        public void DelElement(int id)
        {
            Equipment element = source.Equipments.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.Equipments.Remove(element);
            }
            else
            {
                throw new Exception("Оборудование не найдено");
            }
        }
    }
}
