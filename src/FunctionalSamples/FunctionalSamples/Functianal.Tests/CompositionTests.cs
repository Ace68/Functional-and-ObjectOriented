using FunctionalSamples;

namespace Functional.Tests;

public class CompositionTests
{
    [Fact]
    public void Can_Compose_Two_Functions_Together()
    {
        Func<int, int> tripleAndAddTen = x => CompositionFunction.AddTen(CompositionFunction.Triple(x));
        
        Assert.Equal(19, tripleAndAddTen(3));
    }
    
    [Fact]
    public void Can_Create_Function_Pipeline_Using_Compose()
    {
        var pipeline = CompositionFunction.Compose(CompositionFunction.Triple, CompositionFunction.AddTen);
        
        Assert.Equal(60, pipeline(10));
    }
    
    [Fact]
    public void Can_Compose_Predicates()
    {
        Assert.True(CompositionFunction.IsEvenAndGreaterThanTen(12));
        Assert.False(CompositionFunction.IsEvenAndGreaterThanTen(10));
        Assert.False(CompositionFunction.IsEvenAndGreaterThanTen(11));
    }
    
    [Fact]
    public void Can_Use_Function_As_Parameter()
    {
        Assert.Equal(5, CompositionFunction.ApplyTwice(CompositionFunction.Increment, 3)); // 3 + 1 + 1 = 5
    }
    
    [Fact]
    public void Can_Create_Configurable_Functions()
    {
        var double_ = CompositionFunction.Multiply(2);
        var triple = CompositionFunction.Multiply(3);
        var quadruple = CompositionFunction.Multiply(4);
        
        Assert.Equal(10, double_(5));
        Assert.Equal(15, triple(5));
        Assert.Equal(20, quadruple(5));
    }
    
    [Fact]
    public void Can_Chain_Pure_Functions()
    {
        IEnumerable<int> numbers = Enumerable.Range(1, 5);
        
        var result = numbers
            .Select(PureFunctions.Triple)
            .Select(CompositionFunction.Increment)
            .Select(CompositionFunction.Double)
            .ToList();
        
        // Range: 1,2,3,4,5
        // After Triple: 3,6,9,12,15
        // After +1: 4,7,10,13,16
        // After *2: 8,14,20,26,32
        Assert.Equal([8, 14, 20, 26, 32], result);
    }
}