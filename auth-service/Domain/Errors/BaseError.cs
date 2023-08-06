using System.Text.Json;

namespace auth_service.Domain.Errors
{
    public class BaseError
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public BaseError(int code, string message)
        {
            StatusCode = code;
            Message = message;
            Errors = new List<string>();
        }

        public BaseError(int code, string message, List<string> errors)
        {
            StatusCode = code;
            Message = message;
            Errors = errors;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
