using System.Text.Json;

namespace AuxiliaryServices.Extensions.ErrorHandling
{
    internal class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = "Ok";

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}