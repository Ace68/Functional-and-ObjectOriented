var nums = Enumerable.Range(-100000, 200001).Reverse().ToList();
        
Action task1 = () => Console.WriteLine(nums.Sum());
Action task2 = () =>
{
    nums.Sort(); 
    Console.WriteLine(nums.Sum());
};

// await Task.Run(task1);
Parallel.Invoke(task1, task2);