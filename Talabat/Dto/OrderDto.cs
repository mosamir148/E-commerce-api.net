using System.ComponentModel.DataAnnotations;

namespace Talabat.Dto
{
    public class OrderDto
    {
        
        public string basketId { get; set; }

        public int DeliveryMethodeId { get; set; }

        public AdressDto address { get; set; }
    }
}
