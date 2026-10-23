namespace Whatsaaaa.BuildingBlocks.Domain.Results;

/// <summary>An expected failure: what went wrong, for machines and for people.</summary>
/// <param name="Code">Stable identifier clients can rely on, such as <c>notes.title_taken</c>.</param>
/// <param name="Message">Explanation for people; wording may change at any time.</param>
/// <param name="Kind">The category hosts use to choose a status code.</param>
public sealed record Error(string Code, string Message, ErrorKind Kind)
{
    /// <summary>
    /// Messages per input field for validation failures, keyed by property name.
    /// Null for every other kind of error.
    /// </summary>
    public IReadOnlyDictionary<string, string[]>? Fields { get; init; }

    /// <summary>Creates an error the caller can fix by changing the input.</summary>
    /// <param name="code">The stable code, <c>&lt;module&gt;.&lt;reason&gt;</c>.</param>
    /// <param name="message">The explanation for people.</param>
    public static Error Validation(string code, string message) => new(code, message, ErrorKind.Validation);

    /// <summary>Creates an error for something that does not exist or is not visible.</summary>
    /// <param name="code">The stable code, <c>&lt;module&gt;.&lt;reason&gt;</c>.</param>
    /// <param name="message">The explanation for people.</param>
    public static Error NotFound(string code, string message) => new(code, message, ErrorKind.NotFound);

    /// <summary>Creates an error for a request that conflicts with the current state.</summary>
    /// <param name="code">The stable code, <c>&lt;module&gt;.&lt;reason&gt;</c>.</param>
    /// <param name="message">The explanation for people.</param>
    public static Error Conflict(string code, string message) => new(code, message, ErrorKind.Conflict);

    /// <summary>Creates an error for a caller who lacks the right to do this</summary>
    /// <param name="code">The stable code, <c>&lt;module&gt;.&lt;reason&gt;</c>.</param>
    /// <param name="message">The explanation for people.</param>
    public static Error Forbidden(string code, string message) => new(code, message, ErrorKind.Forbidden);

    /// <summary>Creates an error for a failure the caller cannot fix.</summary>
    /// <param name="code">The stable code, <c>&lt;module&gt;.&lt;reason&gt;</c>.</param>
    /// <param name="message">The explanation for people.</param>
    public static Error Unexpected(string code, string message) => new(code, message, ErrorKind.Unexpected);
}
