namespace FunctionalSamples.CustomTypes;

public static class UsersData
{
    public const decimal DiscountRate = 0.2m;

    public record User(int Id, string Name, string City, Address Address);
    
    private static readonly List<User> Users =
    [
        new(1, "Alice", "New York", new Address("New York", "USA")),
        new(2, "Bob", "Los Angeles", new Address("Los Angeles", "USA")),
        new(3, "Charlie", "Chicago", new Address("Chicago", "USA")),
        new(4, "Diana", "Houston", new Address("Houston", "USA")),
        new(5, "Ethan", "Phoenix", new Address("Phoenix", "USA")),
    ];
    
    public static User? FindUser(int userId) =>
        Users.FirstOrDefault(u => u.Id == userId);
    
    public static Option<User> FindUserWithOption(int userId) =>
        Users.FirstOrDefault(u => u.Id == userId) is { } user
            ? new Option<User>.Some(user)
            : new Option<User>.None();
    
    public static Option<Address> FindUserAddress(int userId) =>
        Users.FirstOrDefault(u => u.Id == userId) is { } user
            ? user.Address is not null
                ? new Option<Address>.Some(user.Address)
                : new Option<Address>.None()
            : new Option<Address>.None();
}