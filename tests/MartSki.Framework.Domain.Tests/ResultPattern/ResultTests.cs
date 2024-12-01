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
        result.Errors.Should().BeNull();
    }

    [TestCase("Mon code erreur 1", "Mon message erreur 1")]
    public void Failure_ErrorObjectWithOneItem_ResultFailure(string code, string message)
    {
        Error[] errors = { new Error(code, message) };
        Result result = Result.Failure(errors);

        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();

        result.Errors.Should().NotBeNull();
        result.Errors![0].Code.Should().Be(code);
        result.Errors![0].Message.Should().Be(message);
    }

    [TestCase("Mon code erreur 1", "Mon message erreur 1", "Mon code erreur 2", "Mon message erreur 2")]
    public void Failure_ErrorObjectWithTwoItems_ResultFailure(string code1, string message1, string code2, string message2)
    {
        Error[] errors = { new Error(code1, message1), new Error(code2, message2) };
        Result result = Result.Failure(errors);

        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();

        result.Errors.Should().NotBeNull();
        result.Errors.Length.Should().Be(2);

        result.Errors![0].Code.Should().Be(code1);
        result.Errors![0].Message.Should().Be(message1);
        result.Errors![1].Code.Should().Be(code2);
        result.Errors![1].Message.Should().Be(message2);
    }

    [Test]
    public void Failure_ErrorObjectNull_Exception()
    {
        Action act = () => Result.Failure(null!);

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(Result.Errors));
    }

    [Test]
    public void SuccessObject_Object_ResultSuccessObject()
    {
        Object objet = new object();
        Result<Object> result = Result<Object>.Success(objet);

        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();

        result.Value.Should().NotBeNull();
        result.Value.GetType().Should().Be(typeof(Object));
        result.Value.Should().Be(objet);

        result.Errors.Should().BeNull();
    }

    [TestCase("Mon code erreur", "Mon message erreur")]
    public void FailureObject_Object_ResultFailureObjectWithOneError(string code, string message)
    {
        Error[] errors = { new Error(code, message) };
        Object objet = new object();
        Result<Object> result = Result<Object>.Failure(objet, errors);

        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();

        result.Value.Should().NotBeNull();
        result.Value.GetType().Should().Be(typeof(Object));
        result.Value.Should().Be(objet);

        result.Errors.Should().NotBeNull();
        result.Errors[0]!.Code.Should().Be(code);
        result.Errors[0]!.Message.Should().Be(message);
    }

    [TestCase("Mon code erreur 1", "Mon message erreur 1", "Mon code erreur 2", "Mon message erreur 2")]
    public void FailureObject_Object_ResultFailureObjectWithTwoErrors(string code1, string message1, string code2, string message2)
    {
        Error[] errors = { new Error(code1, message1), new Error(code2, message2) };
        Object objet = new object();
        Result<Object> result = Result<Object>.Failure(objet, errors);

        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();

        result.Value.Should().NotBeNull();
        result.Value.GetType().Should().Be(typeof(Object));
        result.Value.Should().Be(objet);

        result.Errors.Should().NotBeNull();
        result.Errors.Length.Should().Be(2);

        result.Errors[0]!.Code.Should().Be(code1);
        result.Errors[0]!.Message.Should().Be(message1);

        result.Errors[1]!.Code.Should().Be(code2);
        result.Errors[1]!.Message.Should().Be(message2);
    }

    [TestCase("Mon code erreur", "Mon message erreur")]
    public void FailureObject_NoObject_ResultFailureObjectWithOneError(string code, string message)
    {
        Error[] errors = { new Error(code, message) };
        Result<Object> result = Result<Object>.Failure(errors);

        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();

        result.Value.Should().BeNull();

        result.Errors.Should().NotBeNull();
        result.Errors[0]!.Code.Should().Be(code);
        result.Errors[0]!.Message.Should().Be(message);
    }

    [TestCase("Mon code erreur 1", "Mon message erreur 1", "Mon code erreur 2", "Mon message erreur 2")]
    public void FailureObject_NoObject_ResultFailureObjectWithTwoErrors(string code1, string message1, string code2, string message2)
    {
        Error[] errors = { new Error(code1, message1), new Error(code2, message2) };
        Result<Object> result = Result<Object>.Failure(errors);

        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();

        result.Value.Should().BeNull();

        result.Errors.Should().NotBeNull();
        result.Errors.Length.Should().Be(2);

        result.Errors[0]!.Code.Should().Be(code1);
        result.Errors[0]!.Message.Should().Be(message1);

        result.Errors[1]!.Code.Should().Be(code2);
        result.Errors[1]!.Message.Should().Be(message2);
    }
}
