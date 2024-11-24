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

            Code = code;
            Message = message;
        }
    }
}
