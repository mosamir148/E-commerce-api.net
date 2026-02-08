namespace Talabat.Errors
{
    public class apivlaidationerrors :ApiResponse
    {
        public IEnumerable<string> Errors { get; set; }

        public apivlaidationerrors():base(404)
        {
            Errors = new List<string>();
        }
    }
}
