using FunctionalSamples;

namespace Functional.Tests;

public class HighOrderFunctionsTests
{
    [Fact]
    public void Can_UseIsEvenFunction()
    {
        var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var evenNumbers = numbers.Where(HighOrderFunctions.IsEven);
        
        Assert.Equal([2, 4, 6, 8, 10], evenNumbers);
    }

    [Fact]
    public void Can_UseSquareFunction()
    {
        var numbers = new[] { 1, 2, 3, 4, 5 };
        var squaredNumbers = numbers.Select(HighOrderFunctions.Square);
        
        Assert.Equal([1, 4, 9, 16, 25], squaredNumbers);
    }

    [Fact]
    public void Can_ComposeIsEven_And_Square()
    {
        int[] expected = [4, 16, 36, 64];
        
        var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        var evenSquared = numbers
            .Where(HighOrderFunctions.IsEven)
            .Select(HighOrderFunctions.Square)
            .ToArray();
        
        Assert.Equal(expected, evenSquared);
    }
}