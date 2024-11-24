using MartSki.Framework.Domain.ResultPattern.Interfaces;

namespace MartSki.Framework.Domain.ResultPattern.Models
{
    public class Result<TValue> : Result
    {
        public TValue Value { get; init; }

        private Result(bool isSuccess, TValue value, Error? error = null) : base(isSuccess, error)
        {
            Value = value;
        }

        public static Result<TValue> Success(TValue value) => new Result<TValue>(true, value);
    }

    public class Result : IResult
    {
        public bool IsSuccess { get; init; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; init; }

        protected Result(bool isSuccess, Error? error = null)
        {
            if (!isSuccess && error is null)
                throw new ArgumentNullException(nameof(Result.Error));

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true);
        public static Result Failure(Error error) => new(false, error);
    }
}
