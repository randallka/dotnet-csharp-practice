
namespace CloudCustomers.UnitTests.Systems.Services
{
	public class TestUsersService
	{
		[Fact]
		public async Task GetAllUsers_WhenCalled_InvokesHttpGetRequest()
		{
			//Arrange
			var sut = new UserService();
			//Act
			await sut.GetAllUsers();
;			//Assert
			//verify that an http request is made
		}

	}
}

