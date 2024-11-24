namespace MartSki.Framework.Domain.ResultPattern
{
    public interface IError
    {
        public string Code { get; init; }
        public string Message { get; init; }
    }
}
