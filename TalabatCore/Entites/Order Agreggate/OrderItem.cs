using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalabatCore.Entites.Order_Agreggate
{
    public class OrderItem:BaseEntity
    {

        public OrderItem()
        {
            
        }

        public OrderItem(ProductItemOrder productItemOrder, decimal price, int quantity)
        {
            ProductItemOrder = productItemOrder;
            Price = price;
            this.quantity = quantity;
        }

        public ProductItemOrder ProductItemOrder { get; set; }

        public decimal Price { get; set; }
        public int quantity { get; set; }


    }
}
