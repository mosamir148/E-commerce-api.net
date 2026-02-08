namespace Talabat.Errors
{
    public class ApiResponse
    {
       public int statuscode { get; set; }

       public string? errormassage { get; set; }

        public ApiResponse(int num,string? massage = null)
        {
           this.statuscode = num;
        this.errormassage  = massage ?? gettheerrormassage(statuscode);

        }

        private string? gettheerrormassage(int statuscode)
        {
            return statuscode switch
            {
                400 => "badRequest You have made",
                401 => "ahutorized , you are not ",
                404 => "resourses was not founded",
                500 => "error are the path",
                _=>null
            };
        }
    }
}
