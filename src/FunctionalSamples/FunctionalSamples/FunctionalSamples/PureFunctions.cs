using FunctionalSamples.CustomTypes;

namespace FunctionalSamples;

public static class PureFunctions
{
    public static decimal CalculatePrice(Order order, decimal discountRate) =>
        order.Total - order.Total * discountRate;
    
    public static decimal Price(Order order) =>
        order switch
        {
            { IsVip: true, Total: >= 1000 } => order.Total * 0.8m,
            { Total: >= 2000 } => order.Total * 0.95m,
            _ => order.Total
        };

    public static Func<int,int> Triple = x => x * 3;
    
    public static Func<string, string, Address> CreateAddress = (country, city) =>
        new Address(city, country);
}