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
            .ReturnsAsync(new List<User>());
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
        //act
        //assert
    }
}