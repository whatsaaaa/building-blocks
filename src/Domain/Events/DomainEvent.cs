namespace Whatsaaaa.BuildingBlocks.Domain.Events;

/// <summary>
/// Base record for domain events. Derive one sealed record per fact, named in the past tense,
/// and create it as <c>new NoteRenamed(id, title) { OccurredAt = now }</c>.
/// </summary>
public abstract record DomainEvent : IDomainEvent
{
    /// <summary>
    /// When the event happened. Required: the aggregate passes the time its caller read from a
    /// <see cref="TimeProvider"/>, so tests control it and no event reads the machine clock.
    /// </summary>
    public required DateTimeOffset OccurredAt { get; init; }
}
