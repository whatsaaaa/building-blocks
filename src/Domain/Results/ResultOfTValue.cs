namespace Whatsaaaa.BuildingBlocks.Domain.Results;

/// <summary>The outcome of an operation that produces a <typeparamref name="TValue"/> when it succeeds.</summary>
/// <typeparam name="TValue">The type of the value on success.</typeparam>
public sealed class Result<TValue> : Result
{
    private readonly TValue? _value;

    private Result(TValue value)
        : base(null) => _value = value;

    private Result(Error error)
       : base(error) => _value = default;

    /// <summary>
    /// The value of a successful result. Reading it from a failed result throws, because that
    /// is always a bug: check <see cref="Result.IsSuccess"/> first.
    /// </summary>
    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException($"Cannot read the value of a failed result ({Error.Code}).");

    internal static Result<TValue> FromValue(TValue value) => new(value);

    internal static Result<TValue> FromError(Error error) => new(error);

    /// <summary>Lets a handler <c>return value;</c> instead of <c>return Result.Success(value);</c>.</summary>
    /// <param name="value">The value the operation produced.</param>
    public static implicit operator Result<TValue>(TValue value) => new(value);

    /// <summary>Lets a handler <c>return error;</c> for any result type.</summary>
    /// <param name="error">Why the operation failed.</param>
    public static implicit operator Result<TValue>(Error error) => new(error);
}
