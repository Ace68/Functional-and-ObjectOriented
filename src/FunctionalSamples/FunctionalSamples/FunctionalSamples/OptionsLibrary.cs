using FunctionalSamples.CustomTypes;

namespace FunctionalSamples;

public static class OptionsLibrary
{   
    // Option-based operations
    private static Option<UsersData.User> GetUserAsOption(int userId) =>
        UsersData.FindUser(userId) is { } user
            ? new Option<UsersData.User>.Some(user)
            : new Option<UsersData.User>.None();
    
    // Get user's city using Option/Select
    public static Option<string> GetUserCity(int userId) =>
        GetUserAsOption(userId).Select(user => user.City);
    
    // Chain operations using SelectMany (flatMap)
    public static Option<(UsersData.User User, string UpperCity)> GetUserWithUpperCity(int userId) =>
        GetUserAsOption(userId).SelectMany(user =>
            GetUserCity(userId).Select(city => (user, city.ToUpper()))
        );
    
    // Get user by ID and verify they exist in a list of valid IDs
    public static Option<UsersData.User> GetValidUser(int userId, List<int> validIds) =>
        validIds.Contains(userId)
            ? GetUserAsOption(userId)
            : new Option<UsersData.User>.None();
}