using FluentAssertions;
using MartSki.Framework.Domain.ResultPattern.Models;

namespace MartSki.Framework.Domain.Tests;

public class ResultTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Success_ResultSuccess()
    {
        Result result = Result.Success();

        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Error.Should().BeNull();
    }

    [TestCase("Mon code erreur", "Mon message erreur")]
    public void Failure_ErrorObject_ResultFailure(string code, string message)
    {
        Error error = new Error(code, message);
        Result result = Result.Failure(error);

        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();

        result.Error.Should().NotBeNull();
        result.Error!.Code.Should().Be(code);
        result.Error!.Message.Should().Be(message);
    }

    [Test]
    public void Failure_ErrorObjectNull_Exception()
    {
        Action act = () => Result.Failure(null!);

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(Result.Error));
    }
}
