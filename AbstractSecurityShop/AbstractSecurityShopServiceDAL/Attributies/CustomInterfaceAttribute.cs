using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceDAL.Attributies
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class CustomInterfaceAttribute : Attribute
    {
        public CustomInterfaceAttribute(string descript)
        {
            Description = string.Format("Описание интерфейса: ", descript);
        }
        public string Description { get; private set; }
    }
}
