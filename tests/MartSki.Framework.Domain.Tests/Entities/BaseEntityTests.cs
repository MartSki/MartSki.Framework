using FluentAssertions;
using MartSki.Framework.Domain.Tests.Entities.Models;

namespace MartSki.Framework.Domain.Tests;

public class BaseEntityTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(1, "Bon", "Jean", 42)]
    public void BaseIdInt_ClientAvecId(int id, string nom, string prénom, int age)
    {
        Client client = new(id, nom, prénom, age);

        client.Id.Should().NotBe(null);
        client.Id.GetType().Should().Be(typeof(int));
        client.Id.Should().Be(id);
    }
}
