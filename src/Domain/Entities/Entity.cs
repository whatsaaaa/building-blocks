using Whatsaaaa.BuildingBlocks.Domain.Events;

namespace Whatsaaaa.BuildingBlocks.Domain.Entities;

/// <summary>
/// Base class of every persisted domain object. It collects the domain events the object raises
/// until persistence dispatches them after the next successful save.
/// </summary>
public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = [];

    /// <summary>The events raised since the last dispatch, oldest first.</summary>
    public IReadOnlyList<IDomainEvent> GetDomainEvents() => _domainEvents;

    /// <summary>Forgets raised events; persistence calls this right before dispatching them.</summary>
    public void ClearDomainEvents() => _domainEvents.Clear();

    /// <summary>Records that <paramref name="domainEvent"/> happened to this entity.</summary>
    /// <param name="domainEvent">The fact to record.</param>
    protected void Raise(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}
