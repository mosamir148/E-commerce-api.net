namespace Talabat.Helpres
{
    public class paramgetallproducts
    {
        private const int maxpage = 10;

        public int indexpage { get; set; } = 1;

        private int size;

        public int Pagesize
        {   get { return size; }
            set { size = value > maxpage ? maxpage : value; }
        }

        public string sort { get; set; }
        public int? brands { get; set; }
        public int? types { get; set; }

        private string scerch;

        public string Scerch
        {
            get { return scerch; }
            set { scerch = value.ToLower(); }
        }



    }
}
