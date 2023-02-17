
using System.Xml.Linq;
using CloudCustomers.API.Models;

namespace CloudCustomers.UnitTests.Fixtures
{
    public static class UsersFixture
    {
        public static List<User> GetTestUsers() =>
            new()
            {
                new User {
                    Name = "Test User 1",
                    Address = new Address()
                    {
                        Street = "123 Main st.",
                        City = "Denver",
                        ZipCode = "12345"
                    },
                    Email = "test-user-1@test.org"
                },
                new User {
                    Name = "Test User 2",
                    Address = new Address()
                    {
                        Street = "456 Main st.",
                        City = "Denver",
                        ZipCode = "67891"
                    },
                    Email = "test-user-2@test.org"
                },
                new User {
                    Name = "Test User 3",
                    Address = new Address()
                    {
                        Street = "789 Main st.",
                        City = "Denver",
                        ZipCode = "01112"
                    },
                    Email = "test-user-3@test.org"
                },

            };
    }
}
           

