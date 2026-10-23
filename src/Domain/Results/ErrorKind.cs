namespace Whatsaaaa.BuildingBlocks.Domain.Results;

/// <summary>
/// The category of an expected failure. Hosts translate each kind to exactly one HTTP status,
/// so a use case never needs to know about HTTP..
/// </summary>
public enum ErrorKind
{
    /// <summary>The input breaks a rule the caller can fix (HTTP 400).</summary>
    Validation,

    /// <summary>The target does not exist or is not visible to the caller (HTTP 404).</summary>
    NotFound,

    /// <summary>The request conflicts with current state, such as a code already taken (HTTP 409).</summary>
    Conflict,

    /// <summary>The caller is known but is not allowed to do this (HTTP 403).</summary>
    Forbidden,

    /// <summary>A failure the caller cannot fix (HTTP 500).</summary>
    Unexpected
}
