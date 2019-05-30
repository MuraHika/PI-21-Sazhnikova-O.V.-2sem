using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceDAL.ViewModel
{
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerFIO { get; set; }
        [DataMember]
        public string TechnicsName { get; set; }
        [DataMember]
        public int? WorkerId { get; set; }
        [DataMember]
        public string WorkerName { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public int Sum { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string DateCreate { get; set; }
        [DataMember]
        public string DateImplement { get; set; }
        [DataMember]
        public int TechnicsId { get; set; }
    }
}
