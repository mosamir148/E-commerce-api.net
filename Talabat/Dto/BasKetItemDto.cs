using System.ComponentModel.DataAnnotations;

namespace Talabat.Dto
{
    public class BasKetItemDto
    {

        public string Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="Quantity at least 1")]
        [Required]
        public int Quantity { get; set; }
        [Range(0.1, double.MaxValue, ErrorMessage = "Quantity at least 1")]
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string brands { get; set; }
        [Required]
        public string Types { get; set; }
    }
}
