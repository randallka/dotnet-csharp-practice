using System;
using CloudCustomers.API.Models;

public interface IUsersService
{
    public Task<List<User>> GetAllUsers();
}


public class UserService : IUsersService
	{
    private readonly HttpClient _httpClient;
    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<User>> GetAllUsers()
    {
        var usersResponse = await _httpClient.GetAsync("https://example.com");
        return new List<User> { };
    }
}


