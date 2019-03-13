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
    public class StorageServiceList : IStorageService
    {
        private DataListSingleton source;

        public StorageServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<StorageViewModel> GetList()
        {
            List<StorageViewModel> result = source.Storages.Select(rec => new StorageViewModel
            {
                Id = rec.Id,
                StorageName = rec.StorageName,
                StorageEquipment = source.StorageEquipments.Where(recPC => recPC.StorageId == rec.Id).Select(recPC => new StorageEquipmentViewModel
                {
                    Id = recPC.Id,
                    StorageId = recPC.StorageId,
                    EquipmentId = recPC.EquipmentId,
                    EquipmentName = source.Equipments.FirstOrDefault(recC => recC.Id == recPC.EquipmentId)?.EquipmentName,
                    Count = recPC.Count
                }).ToList()
            }).ToList();
            return result;
        }

        public StorageViewModel GetElement(int id)
        {
            Storage element = source.Storages.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new StorageViewModel
                {
                    Id = element.Id,
                    StorageName = element.StorageName,
                    StorageEquipment = source.StorageEquipments.Where(recPC => recPC.StorageId == element.Id).Select(recPC => new StorageEquipmentViewModel
                    {
                        Id = recPC.Id,
                        StorageId = recPC.StorageId,
                        EquipmentId = recPC.EquipmentId,
                        EquipmentName = source.Equipments.FirstOrDefault(recC => recC.Id == recPC.EquipmentId)?.EquipmentName,
                        Count = recPC.Count
                    }).ToList()
                };
            }
            throw new Exception("Хранилище не найдено");
        }
        public void AddElement(StorageBindingModel model)
        {
            Storage element = source.Storages.FirstOrDefault(rec => rec.StorageName == model.StorageName);
            if (element != null)
            {
                throw new Exception("Уже есть хранилище с таким названием");
            }
            int maxId = source.Storages.Count > 0 ? source.Storages.Max(rec => rec.Id) : 0;
            source.Storages.Add(new Storage
            {
                Id = maxId + 1,
                StorageName = model.StorageName
            });
        }

        public void UpdElement(StorageBindingModel model)
        {
            Storage element = source.Storages.FirstOrDefault(rec =>
            rec.StorageName == model.StorageName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть хранилище с таким названием");
            }
            element = source.Storages.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Хранилище не найдено");
            }
            element.StorageName = model.StorageName;
        }

        public void DelElement(int id)
        {
            Storage element = source.Storages.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // при удалении удаляем все записи о компонентах на удаляемом складе
                source.StorageEquipments.RemoveAll(rec => rec.StorageId == id);
                source.Storages.Remove(element);
            }
            else
            {
                throw new Exception("Хранилище не найдено");
            }
        }
    }
}
