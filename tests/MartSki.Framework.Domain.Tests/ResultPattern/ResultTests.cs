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
}
