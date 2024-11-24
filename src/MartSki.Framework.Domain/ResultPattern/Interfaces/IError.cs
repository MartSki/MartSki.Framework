namespace MartSki.Framework.Domain.ResultPattern.Interfaces
{
    public interface IError
    {
        public string Code { get; init; }
        public string Message { get; init; }
    }
}
