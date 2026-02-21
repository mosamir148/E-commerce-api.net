using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalabatCore.Entites.Order_Agreggate
{
    public class Order:BaseEntity
    {
        public Order()
        {
            
        }
        public Order(
            string buyerEmail,
            Address shippingAddress,
            DeliveryMethode deliveryMethode, 
            ICollection<OrderItem> items, 
            decimal subtotal)
        {
            BuyerEmail = buyerEmail;
            ShippingAddress = shippingAddress;
            DeliveryMethode = deliveryMethode;
            Items = items;
            Subtotal = subtotal;
        }

        public string BuyerEmail { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public DateTimeOffset Orderdate { get; set; } = DateTimeOffset.Now;

        public Address ShippingAddress { get; set; }

        //navigateProparty
        public DeliveryMethode DeliveryMethode { get; set; }

        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();

        public decimal Subtotal { get; set; }

        public string PaymentMethodeId { get; set; } = string.Empty;
        public decimal GetTotal() => DeliveryMethode.Cost + Subtotal;

    }
}
