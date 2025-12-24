namespace FunctionalSamples;

public static class HighOrderFunctions
{
    // HOF example: a function that takes another function as an argument
    static IEnumerable<T> Filter<T>(
        IEnumerable<T> source,
        Func<T, bool> predicate)
    {
        foreach (var x in source)
            if (predicate(x))
                yield return x;
    }
    
    public static readonly Func<int, bool> IsEven = x => x % 2 == 0;
    public static readonly Func<int, int> Square = x => x * x;
}