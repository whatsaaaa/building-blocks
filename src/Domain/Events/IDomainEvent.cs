namespace Whatsaaaa.BuildingBlocks.Domain.Events;

/// <summary>
/// Something that happened inside one module and that other code in the same process may react to.
/// Domain events never leave the process; integration events (Application) do.
/// </summary>
public interface IDomainEvent
{
    /// <summary>When the event happened, in UTC.</summary>
    DateTimeOffset OccurredAt { get; }
}
