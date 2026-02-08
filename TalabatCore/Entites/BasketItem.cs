using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalabatCore.Entites
{
    public class BasketItem
    {
        public string Id { get; set; }

        public string ProductName { get; set; }

        public string PictureUrl { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string brands { get; set; }

        public string Types { get; set; }

    }
}
