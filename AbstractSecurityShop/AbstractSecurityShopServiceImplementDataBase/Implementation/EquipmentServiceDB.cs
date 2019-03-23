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
    public class EquipmentServiceDB : IEquipmentService
    {
        private AbstractSecurityShopDbContext context;        public EquipmentServiceDB(AbstractSecurityShopDbContext context)
        {
            this.context = context;
        }
        public List<EquipmentViewModel> GetList()
        {
            List<EquipmentViewModel> result = context.Equipments.Select(rec => new EquipmentViewModel
            {
                Id = rec.Id,
                EquipmentName = rec.EquipmentName
            }).ToList();
            return result;
        }

        public EquipmentViewModel GetElement(int id)
        {
            Equipment element = context.Equipments.FirstOrDefault(rec => rec.Id == id);
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
            Equipment element = context.Equipments.FirstOrDefault(rec => rec.EquipmentName == model.EquipmentName);
            if (element != null)
            {
                throw new Exception("Уже есть оборудование с таким названием");
            }
            context.Equipments.Add(new Equipment
            {
                EquipmentName = model.EquipmentName
            });
            context.SaveChanges();
        }

        public void UpdElement(EquipmentBindingModel model)
        {
            Equipment element = context.Equipments.FirstOrDefault(rec => rec.EquipmentName == model.EquipmentName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть оборудование с таким названием");
            }
            element = context.Equipments.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Оборудование не найдено");
            }
            element.EquipmentName = model.EquipmentName;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Equipment element = context.Equipments.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Equipments.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Оборудование не найдено");
            }
        }
    }
}
