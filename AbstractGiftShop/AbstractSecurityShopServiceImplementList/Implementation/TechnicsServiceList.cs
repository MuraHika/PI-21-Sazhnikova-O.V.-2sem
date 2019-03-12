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
            List<TechnicsViewModel> result = new List<TechnicsViewModel>();
            for (int i = 0; i < source.Technics.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
                List<TechnicsEquipmentViewModel> TechnicsEquipment = new List<TechnicsEquipmentViewModel>();

                for (int j = 0; j < source.TechnicsEquipment.Count; ++j)
                {
                    if (source.TechnicsEquipment[j].TechnicsId == source.Technics[i].Id)
                    {
                        string EquipmentName = string.Empty;
                        for (int k = 0; k < source.Equipment.Count; ++k)
                        {
                            if (source.TechnicsEquipment[j].EquipmentId ==
                           source.Equipment[k].Id)
                            {
                                EquipmentName = source.Equipment[k].EquipmentName;
                                break;
                            }
                        }
                        TechnicsEquipment.Add(new TechnicsEquipmentViewModel
                        {
                            Id = source.TechnicsEquipment[j].Id,
                            TechnicsId = source.TechnicsEquipment[j].TechnicsId,
                            EquipmentId = source.TechnicsEquipment[j].EquipmentId,
                            EquipmentName = EquipmentName,
                            Count = source.TechnicsEquipment[j].Count
                        });
                    }
                }
                result.Add(new TechnicsViewModel
                {
                    Id = source.Technics[i].Id,
                    TechnicsName = source.Technics[i].TechnicsName,
                    Price = source.Technics[i].Price,
                    TechnicsEquipment = TechnicsEquipment
                });
            }
            return result;
        }

        public TechnicsViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Technics.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
                List<TechnicsEquipmentViewModel> TechnicsEquipment = new List<TechnicsEquipmentViewModel>();
                for (int j = 0; j < source.TechnicsEquipment.Count; ++j)
                {
                    if (source.TechnicsEquipment[j].TechnicsId == source.Technics[i].Id)
                    {
                        string EquipmentName = string.Empty;
                        for (int k = 0; k < source.Equipment.Count; ++k)
                        {
                            if (source.TechnicsEquipment[j].EquipmentId ==
                           source.Equipment[k].Id)
                            {
                                EquipmentName = source.Equipment[k].EquipmentName;
                                break;
                            }
                        }
                        TechnicsEquipment.Add(new TechnicsEquipmentViewModel
                        {
                            Id = source.TechnicsEquipment[j].Id,
                            TechnicsId = source.TechnicsEquipment[j].TechnicsId,
                            EquipmentId = source.TechnicsEquipment[j].EquipmentId,
                            EquipmentName = EquipmentName,
                            Count = source.TechnicsEquipment[j].Count
                        });
                    }
                }
                if (source.Technics[i].Id == id)
                {
                    return new TechnicsViewModel
                    {
                        Id = source.Technics[i].Id,
                        TechnicsName = source.Technics[i].TechnicsName,
                        Price = source.Technics[i].Price,
                        TechnicsEquipment = TechnicsEquipment
                    };
                }
            }
            throw new Exception("Техника не найдена");
        }

        public void AddElement(TechnicsBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Technics.Count; ++i)
            {
                if (source.Technics[i].Id > maxId)
                {
                    maxId = source.Technics[i].Id;
                }
                if (source.Technics[i].TechnicsName == model.TechnicsName)
                {
                    throw new Exception("Уже есть техника с таким названием");
                }
            }
            source.Technics.Add(new Technics
            {
                Id = maxId + 1,
                TechnicsName = model.TechnicsName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = 0;
            for (int i = 0; i < source.TechnicsEquipment.Count; ++i)
            {
                if (source.TechnicsEquipment[i].Id > maxPCId)
                {
                    maxPCId = source.TechnicsEquipment[i].Id;
                }
            }
            // убираем дубли по компонентам
            for (int i = 0; i < model.TechnicsEquipment.Count; ++i)
            {
                for (int j = 1; j < model.TechnicsEquipment.Count; ++j)
                {
                    if (model.TechnicsEquipment[i].EquipmentId ==
                    model.TechnicsEquipment[j].EquipmentId)
                    {
                        model.TechnicsEquipment[i].Count +=
                        model.TechnicsEquipment[j].Count;
                        model.TechnicsEquipment.RemoveAt(j--);
                    }
                }
            }
            // добавляем компоненты
            for (int i = 0; i < model.TechnicsEquipment.Count; ++i)
            {
                source.TechnicsEquipment.Add(new TechnicsEquipment
                {
                    Id = ++maxPCId,
                    TechnicsId = maxId + 1,
                    EquipmentId = model.TechnicsEquipment[i].EquipmentId,
                    Count = model.TechnicsEquipment[i].Count
                });
            }
        }

        public void UpdElement(TechnicsBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Technics.Count; ++i)
            {
                if (source.Technics[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Technics[i].TechnicsName == model.TechnicsName &&
                source.Technics[i].Id != model.Id)
                {
                    throw new Exception("Уже есть техника с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Техника не найдена");
            }
            source.Technics[index].TechnicsName = model.TechnicsName;
            source.Technics[index].Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.TechnicsEquipment.Count; ++i)
            {
                if (source.TechnicsEquipment[i].Id > maxPCId)
                {
                    maxPCId = source.TechnicsEquipment[i].Id;
                }
            }
            // обновляем существуюущие компоненты
            for (int i = 0; i < source.TechnicsEquipment.Count; ++i)
            {
                if (source.TechnicsEquipment[i].TechnicsId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.TechnicsEquipment.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.TechnicsEquipment[i].Id ==
                       model.TechnicsEquipment[j].Id)
                        {
                            source.TechnicsEquipment[i].Count =
                           model.TechnicsEquipment[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем
                    if (flag)
                    {
                        source.TechnicsEquipment.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            for (int i = 0; i < model.TechnicsEquipment.Count; ++i)
            {
                if (model.TechnicsEquipment[i].Id == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.TechnicsEquipment.Count; ++j)
                    {
                        if (source.TechnicsEquipment[j].TechnicsId == model.Id &&
                        source.TechnicsEquipment[j].EquipmentId ==
                       model.TechnicsEquipment[i].EquipmentId)
                        {
                            source.TechnicsEquipment[j].Count +=
                           model.TechnicsEquipment[i].Count;
                            model.TechnicsEquipment[i].Id =
                           source.TechnicsEquipment[j].Id;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.TechnicsEquipment[i].Id == 0)
                    {
                        source.TechnicsEquipment.Add(new TechnicsEquipment
                        {
                            Id = ++maxPCId,
                            TechnicsId = model.Id,
                            EquipmentId = model.TechnicsEquipment[i].EquipmentId,
                            Count = model.TechnicsEquipment[i].Count
                        });
                    }
                }
            }
        }

        public void DelElement(int id)
        {
            // удаяем записи по компонентам при удалении изделия
            for (int i = 0; i < source.TechnicsEquipment.Count; ++i)
            {
                if (source.TechnicsEquipment[i].TechnicsId == id)
                {
                    source.TechnicsEquipment.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Technics.Count; ++i)
            {
                if (source.Technics[i].Id == id)
                {
                    source.Technics.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Техника не найдена");
        }
    }
}
