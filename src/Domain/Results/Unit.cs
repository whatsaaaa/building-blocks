namespace Whatsaaaa.BuildingBlocks.Domain.Results;

/// <summary>
/// The value of a command that only succeeds or fails, so every use case can return
/// <c>Result&lt;T&gt;</c> and the pipeline needs one shape only.
/// </summary>
public readonly record struct Unit
{
    /// <summary>The only value of <see cref="Unit" />.</summary>
    public static Unit Value => default;
}
