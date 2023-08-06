namespace auth_service.Application.DTOs
{
    public class BaseResponse<T> where T : class
    {
        public int StatusCode { get; set; }
        public T Data { get; set; }

        public BaseResponse(int code, T data)
        {
            StatusCode = code;
            Data = data;
        }
    }
}
