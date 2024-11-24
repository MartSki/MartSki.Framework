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

    [Test]
    public void Erreur_CodeErreurNull_ArgumentNullException()
    {
        string code = null!;
        string message = "Mon message";

        Action act = () => new Error(code, message);

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(Error.Code));
    }

    [Test]
    public void Erreur_CodeErreurEmpty_ArgumentNullException()
    {
        string code = String.Empty;
        string message = "Mon message";

        Action act = () => new Error(code, message);

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(Error.Code));
    }

    [Test]
    public void Erreur_CodeErreurWhiteSpaces_ArgumentNullException()
    {
        string code = "  ";
        string message = "Mon message";

        Action act = () => new Error(code, message);

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(Error.Code));
    }

    [Test]
    public void Erreur_MessageErreurNull_ArgumentNullException()
    {
        string code = "Mon code";
        string message = null!;

        Action act = () => new Error(code, message);

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(Error.Message));
    }

    [Test]
    public void Erreur_MessageErreurEmpty_ArgumentNullException()
    {
        string code = "Mon code";
        string message = string.Empty;

        Action act = () => new Error(code, message);

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(Error.Message));
    }

    [Test]
    public void Erreur_MessageErreurWhiteSpaces_ArgumentNullException()
    {
        string code = "Mon code";
        string message = "  ";

        Action act = () => new Error(code, message);

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(Error.Message));
    }
}
