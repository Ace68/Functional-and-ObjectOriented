using FunctionalSamples.CustomTypes;

namespace Functional.Tests;

public class MonadTests
{
    [Fact]
    public void Get_City_From_Address_Should_Return_Correct_City_With_Null_Checking()
    {
        var userId = 2;
        var user = UsersData.FindUser(userId);
        if (user != null)
        {
            Assert.Equal("Los Angeles", user.City);
        }
    }
    
    [Fact]
    public void Get_City_From_Address_Should_Return_Correct_City_Without_Null_Checking()
    {
        var userId = 2;
        
        // Use Option monad to extract city from user's address - no null checking needed
        var city =
            from address in UsersData.FindUserAddress(userId)
            select address.City;
        
        // Assert the result using GetOrElse to handle None case
        var result = city.GetOrElse("Unknown");
        Assert.Equal("Los Angeles", result);
    }
}