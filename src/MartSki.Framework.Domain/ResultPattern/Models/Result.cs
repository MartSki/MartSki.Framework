using MartSki.Framework.Domain.ResultPattern.Interfaces;

namespace MartSki.Framework.Domain.ResultPattern.Models
{
    public class Result : IResult
    {
        public bool IsSuccess { get; init; }
        public bool IsFailure { get; init; }
        public Error Error { get; init; }

        protected Result(bool isSuccess, Error? error = null)
        {
            IsSuccess = isSuccess;
            IsFailure = isFailure;
            Error = error;
        }

        public static Result Success() => new(true);
    }
}
