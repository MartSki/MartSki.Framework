using MartSki.Framework.Domain.Entities.Interfaces;

namespace MartSki.Framework.Domain.Entities.Models
{
    public abstract class BaseEntity<TId> : IEntity<TId>
    {
        public TId Id { get; init; }

        protected BaseEntity(TId id)
        {
            Id = id;
        }
    }
}
