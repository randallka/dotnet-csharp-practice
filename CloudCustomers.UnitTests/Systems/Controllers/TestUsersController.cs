using CloudCustomers.API.Controllers;
using CloudCustomers.API.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
namespace CloudCustomers.UnitTests.Systems.Controllers;

public class TestUsersController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        //Arrange: setup system and arrange state
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>()
            {
                new()
                {
                    Id = 1,
                    Name = "randall",
                    Address = new Address()
                    {
                        Street = "123 Main st.",
                        City = "Denver",
                        ZipCode = "12345"
                    },
                    Email = "Randall@example.com"
                }
            });
        var sut = new UsersController(mockUsersService.Object);
        //Act: make something happen (call method under test)
        var result = (OkObjectResult)await sut.Get();
        //Assert: What is the expected outcome? 
        result.StatusCode.Should().Be(200);

    }
    [Fact]
    public async Task Get_OnSuccess_InvokesUserServiceExactlyOnce()
    {
        //Arrange: setup system and arrange state
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());
        var sut = new UsersController(mockUsersService.Object);
        //Act: make something happen (call method under test)
        var result = await sut.Get();
        //Assert: What is the expected outcome?
        mockUsersService.Verify(
            service => service.GetAllUsers(),
            Times.Once());
    }
    [Fact]
    public async Task Get_OnSuccess_ReturnsListOfUsers()
    {
        //Arrange
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>()
            {
                new()
                {
                    Id = 1,
                    Name = "randall",
                    Address = new Address()
                    {
                        Street = "123 Main st.",
                        City = "Denver",
                        ZipCode = "12345"
                    },
                    Email = "Randall@example.com"
                }
            });
        var sut = new UsersController(mockUsersService.Object);
        //act
        var result = await sut.Get();

        //assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<User>>();

    }

    [Fact]
    public async Task Get_OnNoUsersFound_Returns404()
    {
        //Arrange
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());
        var sut = new UsersController(mockUsersService.Object);
        //act
        var result = await sut.Get();

        //assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);

    }


}