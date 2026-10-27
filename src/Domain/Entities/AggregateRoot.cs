namespace Whatsaaaa.BuildingBlocks.Domain.Entities;

/// <summary>
/// The entry point of a consistency boundary. Use cases load and save aggregate roots; child
/// entities change only through methods on their root.
/// </summary>
/// <typeparam name="TId">The aggregate's ID type.</typeparam>
public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : struct
{
}
