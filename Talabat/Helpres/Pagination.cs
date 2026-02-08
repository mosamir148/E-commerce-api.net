using Talabat.Dto;

namespace Talabat.Helpres
{
    public class Pagination<T>
    {
        public int indexpage { get; set; }

        public int take { get; set; }

        public int count { get; set; }

        public IReadOnlyList<T> Data { get; set; }

        public Pagination(int index, int take,int count, IReadOnlyList<T> data)
        {
            this.indexpage = index;
            this.take = take;
            this.count = count;
            this.Data = data;
        }

    }
}
