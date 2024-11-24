using MartSki.Framework.Domain.ResultPattern.Models;

namespace MartSki.Framework.Domain.ResultPattern.Interfaces
{
    public interface IResult<TValue> : IResult
    {
        TValue Value { get; init; }
    }

    public interface IResult
    {
        public bool IsSuccess { get; init; }
        public bool IsFailure { get; init; }
        public Error Error { get; init; }
    }
}
