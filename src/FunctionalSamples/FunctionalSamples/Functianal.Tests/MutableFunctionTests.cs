using FunctionalSamples;
using FunctionalSamples.CustomTypes;
using static System.Linq.Enumerable;
using static System.Console;

namespace Functional.Tests;

public class MutableFunctionTests
{
    [Fact]
    public void Can_Apply_Discount_Without_Knowing_DiscountRate()
    {
        var order = new Order(Total: 1000m, IsVip: true);
        var finalPrice = MutableFunctions.CalculatePrice(order);
        
        Assert.Equal(800m, finalPrice);
    }
    
    [Fact]
    public void Can_Mutate_State()
    {
        List<int> original = [1, 3, 2];
        original.Sort();
        
        Assert.Equal([1, 2, 3], original);
    }
    
    [Fact]
    public void Can_Avoid_Mutate_State()
    {
        List<int> original = [1, 3, 2];
        var sorted = original.OrderBy(x => x).ToList();
        
        Assert.Equal([1, 3, 2], original);
        Assert.Equal([1, 2, 3], sorted);
    }

    [Fact]
    public void Can_Invoke_Concurrent_Processes()
    {
        var nums = Range(-10000, 20001).Reverse().ToList();
        
        Action task1 = () => WriteLine(nums.Sum());
        Action task2 = () => { nums.Sort(); WriteLine(nums.Sum()); };
        
        Parallel.Invoke(task1, task2);
    }
    
    [Fact]
    public void Can_Use_MutableFunction()
    {
        IEnumerable<int> range = [1, 2, 3];
        List<int> triples = [];
        
        foreach (var i in range)
        {
            triples.Add(FunctionalSamples.MutableFunctions.TripleMutable(i));
        }
        
        Assert.Equal([3,6,9], triples);
    }
}