using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalabatCore.Entites.Order_Agreggate
{
    public class DeliveryMethode :BaseEntity
    {
        public DeliveryMethode()
        {
            
        }

        public DeliveryMethode(string shortName, string descriptipn, decimal cost, string deliverTime)
        {
            ShortName = shortName;
            Description = descriptipn;
            Cost = cost;
            DeliveryTime = deliverTime;
        }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }

        public string DeliveryTime { get; set; }
    }
}
