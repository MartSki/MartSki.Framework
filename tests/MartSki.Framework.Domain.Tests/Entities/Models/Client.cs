using MartSki.Framework.Domain.Entities.Models;

namespace MartSki.Framework.Domain.Tests.Entities.Models
{
    internal class Client : BaseEntity<int>
    {
        public string Nom { get; init; }
        public string Prénom { get; init; }
        public int Age { get; init; }

        public Client(int id, string nom, string prénom, int age) : base(id)
        {
            Nom = nom;
            Prénom = prénom;
            Age = age;
        }
    }
}
