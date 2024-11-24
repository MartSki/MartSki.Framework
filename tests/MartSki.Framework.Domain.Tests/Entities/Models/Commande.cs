using MartSki.Framework.Domain.Entities.Models;

namespace MartSki.Framework.Domain.Tests.Entities.Models
{
    internal class Commande : BaseEntity<Guid>
    {
        public DateTime DateCommande { get; init; }
        public int NombreArticles { get; init; }

        public Commande(Guid id, DateTime dateCommande, int nombreArticles) : base(id)
        {
            DateCommande = dateCommande;
            NombreArticles = nombreArticles;
        }
    }
}
