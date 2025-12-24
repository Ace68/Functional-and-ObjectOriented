namespace FunctionalSamples.CustomTypes;

// Option<T> monad for handling null values functionally
public abstract record Option<T>
{
    public sealed record Some(T Value) : Option<T>;
    public sealed record None : Option<T>;
    
    // Map/Select: Transform the value inside the Option if it exists
    public Option<TU> Select<TU>(Func<T, TU> f) =>
        this switch
        {
            Some(var value) => new Option<TU>.Some(f(value)),
            _ => new Option<TU>.None()
        };
    
    // FlatMap/SelectMany: Chain operations that return Options
    public Option<TU> SelectMany<TU>(Func<T, Option<TU>> f) =>
        this switch
        {
            Some(var value) => f(value),
            _ => new Option<TU>.None()
        };
    
    // GetOrElse: Extract value with a default
    public T GetOrElse(T defaultValue) =>
        this switch
        {
            Some(var value) => value,
            _ => defaultValue
        };
    
    // Match: Handle both Some and None cases
    public TU Match<TU>(Func<T, TU> onSome, Func<TU> onNone) =>
        this switch
        {
            Some(var value) => onSome(value),
            _ => onNone()
        };
}