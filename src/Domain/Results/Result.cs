using System.Diagnostics.CodeAnalysis;

namespace Whatsaaaa.BuildingBlocks.Domain.Results;

/// <summary>
/// The outcome of an operation without a value: success, or an <see cref="Results.Error"/>.
/// Expected failures tavel as results; exceptions stay reserved for bugs and outages.
/// </summary>
public class Result
{
    /// <summary>Creates a result.  A null <paramref name="error"/> means success.</summary>
    /// <param name="error">Why the operation failed, or null when it succeeded.</param>
    protected Result(Error? error) => Error = error;

    /// <summary>True when the operation succeeded. When false, <see cref="Error"/> is not null.</summary>
    [MemberNotNullWhen(false, nameof(Error))]
    public bool IsSuccess => Error is null;

    /// <summary>True when the operation failed. When true, <see cref="Error"/> is not null.</summary>
    [MemberNotNullWhen(true, nameof(Error))]
    public bool IsFailure => Error is not null;

    /// <summary>Why the operation failed; null on success.</summary>
    public Error? Error { get; }

    /// <summary>A successful result without a value.</summary>
    public static Result Success() => new(null);

    /// <summary>A failed result.</summary>
    /// <param name="error">Why the operation failed.</param>
    public static Result Failure(Error error) => new(error);

    /// <summary>A successful result carrying <paramref name="value"/>.</summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="value">The value the operation produced.</param>
    public static Result<TValue> Success<TValue>(TValue value) => Result<TValue>.FromValue(value);

    /// <summary>A failed result of type <typeparamref name="TValue"/>.</summary>
    /// <typeparam name="TValue">The type the operation would have produced.</typeparam>
    /// <param name="error">Why the operation failed.</param>
    public static Result<TValue> Failure<TValue>(Error error) => Result<TValue>.FromError(error);

    /// <summary>Lets a method that returns <see cref="Result"/> simply <c>return error;</c>.</summary>
    /// <param name="error">Why the operation failed.</param>
    public static implicit operator Result(Error error) => new(error);
}
