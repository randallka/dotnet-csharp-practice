﻿using System;
using CloudCustomers.API.Models;
using Microsoft.Extensions.Options;
using UsersAPI.Config;

public interface IUsersService
{
    public Task<List<User>> GetAllUsers();
}


public class UserService : IUsersService
	{
    private readonly HttpClient _httpClient;
    private readonly UsersAPIOptions _apiConfig;

    public UserService (
        HttpClient httpClient,
        IOptions<UsersAPIOptions> apiConfig
        )
    {
        _httpClient = httpClient;
        _apiConfig = apiConfig.Value;
    }

    public async Task<List<User>> GetAllUsers()
    {
        var usersResponse = await _httpClient.GetAsync(_apiConfig.Endpoint);
        if (usersResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return new List<User>();
        }
        var responseContent = usersResponse.Content;
        var allUsers = await responseContent.ReadFromJsonAsync<List<User>>();
        return allUsers.ToList();
        
    }
}


