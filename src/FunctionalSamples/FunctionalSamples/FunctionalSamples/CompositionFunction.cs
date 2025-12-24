namespace FunctionalSamples;

public static class CompositionFunction
{
    public static Func<int, int> Double = x => x * 2;
    public static Func<int, int> Triple = x => x * 3;
    public static Func<int, int> AddTen = x => x + 10;
    public static Func<int, int> Increment = x => x + 1;
    
    // Higher-order function that takes a function
    public static readonly Func<Func<int, int>, int, int> ApplyTwice = 
        (f, x) => f(f(x));
    public static readonly Func<Func<int, int>, Func<int, int>, Func<int, int>> Compose = 
        (f, g) => x => f(g(x));
    
    // Create a function factory
    public static readonly Func<int, Func<int, int>> Multiply = 
        factor => x => x * factor;
    
    public static readonly Func<int, bool> IsEven = x => x % 2 == 0;
    public static readonly Func<int, bool> IsGreaterThanTen = x => x > 10;
    public static readonly Func<int, bool> IsEvenAndGreaterThanTen = x => 
        IsEven(x) && IsGreaterThanTen(x);
}