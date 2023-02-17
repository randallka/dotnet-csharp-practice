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

    public Task<List<User>> GetAllUsers()
    {
        throw new NotImplementedException();
    }
}


