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
        if (usersResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return new List<User>();
        }
        var responseContent = usersResponse.Content;
        var allUsers = await responseContent.ReadFromJsonAsync<List<User>>();
        return allUsers.ToList();
        
    }
}


