namespace Whatsaaaa.BuildingBlocks.Domain.Entities;

/// <summary>An entity identified by a typed ID such as <c>NoteId</c>.</summary>
/// <typeparam name="TId">The entity's ID type; a struct so IDs never need null checks.</typeparam>
public abstract class Entity<TId> : Entity
    where TId : struct
{
    /// <summary>The identity of this entity, set once when it is created.</summary>
    public TId Id { get; protected init; }
}
