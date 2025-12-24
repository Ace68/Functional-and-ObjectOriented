using FunctionalSamples;

namespace Functional.Tests;

public class FunctorTests
{
        [Fact]
        public void Can_Option_Select_Works_For_NullSafety()
        {
            int userId = 2;
            var cityOption = OptionsLibrary.GetUserCity(userId);
            
            var city = cityOption.Match(
                onSome: c => c,
                onNone: () => "Unknown"
            );
            
            Assert.Equal("Los Angeles", city);
        }

        [Fact]
        public void Can_Option_Select_Handles_None()
        {
            int userId = 999;
            var cityOption = OptionsLibrary.GetUserCity(userId);
            
            var address = cityOption.Match(
                onSome: c => PureFunctions.CreateAddress(c, "USA"),
                onNone: () => PureFunctions.CreateAddress("Unknown", "Unknown")
            );
            
            Assert.Equal("Unknown", address.City);
        }

        [Fact]
        public void Can_Option_SelectMany_Chains_Operations()
        {
            // SelectMany (flatMap) chains Option-returning operations
            int userId = 1;
            var result = OptionsLibrary.GetUserWithUpperCity(userId);
            
            var message = result.Match(
                onSome: tuple => $"{tuple.User.Name} lives in {tuple.UpperCity}",
                onNone: () => "User not found"
            );
            
            Assert.Equal("Alice lives in NEW YORK", message);
        }

        [Fact]
        public void Can_Option_SelectMany_Handles_None_In_Chain()
        {
            // SelectMany short-circuits when any step returns None
            int userId = 999;
            var result = OptionsLibrary.GetUserWithUpperCity(userId);
            
            var message = result.Match(
                onSome: tuple => $"{tuple.User.Name}",
                onNone: () => "Not found"
            );
            
            Assert.Equal("Not found", message);
        }

        [Fact]
        public void Can_Option_GetOrElse_Provides_Default()
        {
            // GetOrElse extracts the value or uses a default
            int userId = 3;
            var cityOption = OptionsLibrary.GetUserCity(userId);
            var city = cityOption.GetOrElse("Default City");
            
            Assert.Equal("Chicago", city);
        }

        [Fact]
        public void Can_Option_GetOrElse_Returns_Default_For_None()
        {
            // GetOrElse returns default when Option is None
            int userId = 999;
            var cityOption = OptionsLibrary.GetUserCity(userId);
            var city = cityOption.GetOrElse("Default City");
            
            Assert.Equal("Default City", city);
        }

        [Fact]
        public void Can_GetValidUser_Filters_With_Option()
        {
            // Combining multiple conditions using Option
            var validIds = new List<int> { 1, 2, 3 };
            
            var user2 = OptionsLibrary.GetValidUser(2, validIds);
            var user10 = OptionsLibrary.GetValidUser(10, validIds);
            
            var result2 = user2.Match(
                onSome: u => u.Name,
                onNone: () => "Invalid"
            );
            
            var result10 = user10.Match(
                onSome: u => u.Name,
                onNone: () => "Invalid"
            );
            
            Assert.Equal("Bob", result2);
            Assert.Equal("Invalid", result10);
        }    
}