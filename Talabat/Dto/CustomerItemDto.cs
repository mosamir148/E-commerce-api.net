using TalabatCore.Entites;

namespace Talabat.Dto
{
    public class CustomerItemDto
    {
        public string Id { get; set; }

        public List<BasKetItemDto> Items { get; set; }
    }
}
