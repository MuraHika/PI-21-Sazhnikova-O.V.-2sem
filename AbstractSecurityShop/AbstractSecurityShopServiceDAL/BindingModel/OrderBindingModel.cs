﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbstractSecurityShopServiceDAL.BindingModel
{
    [DataContract]
    public class OrderBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int TechnicsId { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public int Sum { get; set; }
    }
}
