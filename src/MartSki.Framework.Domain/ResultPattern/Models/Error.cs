using MartSki.Framework.Domain.ResultPattern.Interfaces;

namespace MartSki.Framework.Domain.ResultPattern.Models
{
    public class Error : IError
    {
        public string Code { get; init; }
        public string Message { get; init; }

        public Error(string code, string message)
        {
            if (String.IsNullOrWhiteSpace(code))
                throw new ArgumentNullException(nameof(Error.Code));
            if (String.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException(nameof(Error.Message));

            Code = code;
            Message = message;
        }
    }
}
