﻿
using CloudCustomers.API.Models;
using CloudCustomers.UnitTests.Fixtures;
using CloudCustomers.UnitTests.Helpers;
using FluentAssertions;
using Moq;
using Moq.Protected;

namespace CloudCustomers.UnitTests.Systems.Services
{
	public class TestUsersService
	{
		[Fact]
		public async Task GetAllUsers_WhenCalled_InvokesHttpGetRequest()
		{
			//Arrange
			var expectedResponse = UsersFixture.GetTestUsers();

			var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
			var httpClient = new HttpClient(handlerMock.Object);
			var sut = new UserService(httpClient);
			//Act
			await sut.GetAllUsers();

;           //Assert
			//verify that an http request is made exactly once

			handlerMock
				.Protected()
				.Verify(
				"SendAsync",
				Times.Exactly(1),
				ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
				ItExpr.IsAny<CancellationToken>()
				);

		}

		[Fact]
		public async Task GetAllUsers_WhenHits404_ReturnsEmptyListOfUsers()
		{
            //Arrange
            var expectedResponse = UsersFixture.GetTestUsers();

            var handlerMock = MockHttpMessageHandler<User>.SetupReturn404();
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new UserService(httpClient);
            //Act
            var result = await sut.GetAllUsers();

             //Assert
			
			result.Count.Should().Be(0);
        }
        [Fact]
        public async Task GetAllUsers_WhenCalled_ReturnsListOfUsersOfExpectedSize()
        {
            //Arrange
            var expectedResponse = UsersFixture.GetTestUsers();

            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new UserService(httpClient);
            //Act
            var result = await sut.GetAllUsers();

            //Assert

            result.Count.Should().Be(expectedResponse.Count);
        }

    }
}

