using System;
using CloudCustomers.API.Models;

public interface IUsersService
{
    public Task<List<User>> GetAllUsers();
}


public class UserService : IUsersService
	{
    public Task<List<User>> GetAllUsers()
    {
        throw new NotImplementedException();
    }
}


