using MartSki.Framework.Domain.ResultPattern.Interfaces;

namespace MartSki.Framework.Domain.ResultPattern.Models
{
    public class Result<TValue> : Result
    {
        public TValue Value { get; init; }

        private Result(bool isSuccess, Error[]? errors = null, TValue value = default) : base(isSuccess, errors)
        {
            Value = value;
        }

        private Result(bool isSuccess, TValue value = default, Error[]? errors = null) : base(isSuccess, errors)
        {
            Value = value;
        }

        public static Result<TValue> Success(TValue value) => new Result<TValue>(true, value);

        public static new Result<TValue> Failure(Error[] errors) => new Result<TValue>(false, errors);

        public static Result<TValue> Failure(TValue value, Error[] errors) => new Result<TValue>(false, value, errors);
    }

    public class Result : IResult
    {
        public bool IsSuccess { get; init; }
        public bool IsFailure => !IsSuccess;
        public Error[] Errors { get; init; }

        protected Result(bool isSuccess, Error[]? errors = null)
        {
            if (!isSuccess && errors is null)
                throw new ArgumentNullException(nameof(Result.Errors));

            IsSuccess = isSuccess;
            Errors = errors;
        }

        public static Result Success() => new(true);
        public static Result Failure(Error[] errors) => new(false, errors);
    }
}
