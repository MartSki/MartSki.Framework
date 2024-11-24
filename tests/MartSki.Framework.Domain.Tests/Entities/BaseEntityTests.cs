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

    [TestCase("9E40C7D9-473B-4B9E-9BA9-3F811242CDDD", "2024-11-24", 2)]
    public void BaseIdGuid_CommandeAvecGuid(string id, DateTime dateCommande, int nombreArticles)
    {
        Guid guid = Guid.Parse(id);
        Commande commande = new(guid, dateCommande, nombreArticles);

        commande.Id.Should().NotBe(Guid.Empty);
        commande.Id.GetType().Should().Be(typeof(Guid));
        commande.Id.Should().Be(guid);
    }
}
