namespace MartSki.Framework.Domain.Entities.Interfaces
{
    public interface IEntity<TId> : IEntity
    {
        TId Id { get; init; }
    }

    public interface IEntity
    { }
}
