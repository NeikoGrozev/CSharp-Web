﻿namespace Andreys.Services
{
    public interface IUsersService
    {
        string GetUserId(string username, string password);

        void CreateUser(string username, string email, string password);

        bool UsernameExists(string username);

        bool EmailExists(string email);
    }
}
