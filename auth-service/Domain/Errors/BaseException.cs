using System.Text.Json;

namespace auth_service.Domain.Errors
{
    public class BaseException : Exception
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public BaseException(int code, string message)
        {
            StatusCode = code;
            Message = message;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
