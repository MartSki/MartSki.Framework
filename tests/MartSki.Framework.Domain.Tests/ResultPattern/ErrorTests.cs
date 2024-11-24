using FluentAssertions;
using MartSki.Framework.Domain.ResultPattern.Models;

namespace MartSki.Framework.Domain.Tests;

public class ErrorTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("Mon code", "Mon Message")]
    public void Erreur_CodeEtMessageDéfinis_ErreurAvecCodeEtMessage(string code, string message)
    {
        Error error = new(code, message);

        error.Code.Should().Be(code);
        error.Message.Should().Be(message);
    }
}
