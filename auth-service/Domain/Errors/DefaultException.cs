using System.Text.Json;

namespace auth_service.Domain.Errors
{
    public class DefaultException : BaseException
    {
        public List<string> Errors { get; set; }
        public DefaultException(int code, string message, List<string> errors) : base(code, message)
        {
            this.Errors = errors;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
