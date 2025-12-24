using FunctionalSamples.CustomTypes;

namespace FunctionalSamples;

public static class MutableFunctions
{
    public static int TripleMutable(int x) => x * 3;
    
    public static void InvokeConcurrentProcesses()
    {
        var nums = Enumerable.Range(-10000, 20001).Reverse().ToList();
        
        Action task1 = () => Console.WriteLine(nums.Sum());
        Action task2 = () => { nums.Sort(); Console.WriteLine(nums.Sum()); };
        
        Parallel.Invoke(task1, task2);
    }
    
    public static decimal CalculatePrice(Order order)
    {
        return order.Total - order.Total * UsersData.DiscountRate;
    }
}