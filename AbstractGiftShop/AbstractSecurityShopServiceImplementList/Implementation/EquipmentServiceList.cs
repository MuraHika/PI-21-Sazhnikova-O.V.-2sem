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
            List<EquipmentViewModel> result = new List<EquipmentViewModel>();
            for (int i = 0; i < source.Equipment.Count; ++i)
            {
                List<TechnicsEquipmentViewModel> TechnicsEquipment = new List<TechnicsEquipmentViewModel>();

                for (int j = 0; j < source.TechnicsEquipment.Count; ++j)
                {
                    if (source.TechnicsEquipment[j].EquipmentId == source.Equipment[i].Id)
                    {
                        TechnicsEquipment.Add(new TechnicsEquipmentViewModel
                        {
                            Id = source.TechnicsEquipment[j].Id,
                            TechnicsId = source.TechnicsEquipment[j].TechnicsId,
                            EquipmentId = source.TechnicsEquipment[j].EquipmentId,
                            EquipmentName = source.TechnicsEquipment[j].EquipmentName,
                            Count = source.TechnicsEquipment[j].Count
                        });
                    }
                }
                result.Add(new EquipmentViewModel
                {
                    Id = source.Equipment[i].Id,
                    EquipmentName = source.Equipment[i].EquipmentName
                });
            }
            return result;
        }

        public EquipmentViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Equipment.Count; ++i)
            {
                if (source.Equipment[i].Id == id)
                {
                    return new EquipmentViewModel
                    {
                        Id = source.Equipment[i].Id,
                        EquipmentName = source.Equipment[i].EquipmentName
                    };
                }
            }
            throw new Exception("Материал не найден");
        }

        public void AddElement(EquipmentBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Equipment.Count; ++i)
            {
                if (source.Equipment[i].Id > maxId)
                {
                    maxId = source.Equipment[i].Id;
                }
                if (source.Equipment[i].EquipmentName == model.EquipmentName)
                {
                    throw new Exception("Уже есть материал с таким названием");
                }
            }
            source.Equipment.Add(new Equipment
            {
                Id = maxId + 1,
                EquipmentName = model.EquipmentName
            });
        }

        public void UpdElement(EquipmentBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Equipment.Count; ++i)
            {
                if (source.Equipment[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Equipment[i].EquipmentName == model.EquipmentName &&
                source.Equipment[i].Id != model.Id)
                {
                    throw new Exception("Уже есть материал с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Материал не найден");
            }
            source.Equipment[index].EquipmentName = model.EquipmentName;
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.Equipment.Count; ++i)
            {
                if (source.Equipment[i].Id == id)
                {
                    source.Equipment.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Материал не найден");
        }
    }
}
