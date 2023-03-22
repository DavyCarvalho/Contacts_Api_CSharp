namespace Utils.Api
{
    public class ApiResponse<T>
    {
        public T Response { get; set; }
        public string ErrorMessage { get; set; }

        public ApiResponse(T response, string errorMessage = null)
        {
            Response = response;
            ErrorMessage = errorMessage;
        }
    }

    public class ApiResponse
    {
        public string ErrorMessage { get; set; }

        public ApiResponse(string errorMessage = null)
        {
            ErrorMessage = errorMessage;
        }
    }
}
