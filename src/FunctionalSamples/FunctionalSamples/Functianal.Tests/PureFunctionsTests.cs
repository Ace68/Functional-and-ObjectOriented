using FunctionalSamples;
using FunctionalSamples.CustomTypes;

namespace Functional.Tests;

public class PureFunctionsTests
{
    [Fact]
    public void Can_Apply_Discount_Without_Knowing_DiscountRate()
    {
        var order = new Order(Total: 1000m, IsVip: true);
        var finalPrice = PureFunctions.CalculatePrice(order, 0.2m);
        
        Assert.Equal(800m, finalPrice);
    }
    
    [Fact]
    public void Can_Apply_VipDiscount_When_VipCustomerWithLowTotal()
    {
        var order = new Order(Total: 800m, IsVip: true);
        var finalPrice = PureFunctions.Price(order);
        
        Assert.Equal(800m, finalPrice);
    }
    
    [Fact]
    public void Can_Use_PureFunctions()
    {
        IEnumerable<int> range = Enumerable.Range(1, 3);

        IEnumerable<int> triples  = range.Select(PureFunctions.Triple);
        
        Assert.Equal([3,6,9], triples);
    }
    
    [Fact]
    public void Can_Apply_VipDiscount_When_VipCustomerWithHighTotal()
    {
        var order = new Order(Total: 1000m, IsVip: true);
        var finalPrice = PureFunctions.Price(order);
        
        Assert.Equal(800m, finalPrice);
    }

    [Fact]
    public void Can_Apply_StandardDiscount_When_HighTotalRegularCustomer()
    {
        var order = new Order(Total: 2000m, IsVip: false);
        var finalPrice = PureFunctions.Price(order);
        
        Assert.Equal(1900m, finalPrice);
    }

    [Fact]
    public void Can_Apply_NoDiscount_For_SmallRegularOrder()
    {
        var order = new Order(Total: 500m, IsVip: false);
        var finalPrice = PureFunctions.Price(order);
        
        Assert.Equal(500m, finalPrice);
    }

    [Fact]
    public void Can_Apply_NoDiscount_For_VipCustomerBelowThreshold()
    {
        var order = new Order(Total: 999m, IsVip: true);
        var finalPrice = PureFunctions.Price(order);
        
        Assert.Equal(999m, finalPrice);
    }

    [Fact]
    public void Can_Apply_VipDiscount_Takes_Precedence()
    {
        var order = new Order(Total: 2000m, IsVip: true);
        var finalPrice = PureFunctions.Price(order);
        
        Assert.Equal(1600m, finalPrice);
    }
}