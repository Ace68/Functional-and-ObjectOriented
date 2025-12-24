using StateMonad;

var increment =
    from current in State.Get<int>()
    from _ in State.Put(current + 1)
    select current;
    
var (value1, state1) = increment.Run(42);

Console.WriteLine("Example 1:");
Console.WriteLine($"Returned value: {value1}");
Console.WriteLine($"Final state:    {state1}");
Console.WriteLine();