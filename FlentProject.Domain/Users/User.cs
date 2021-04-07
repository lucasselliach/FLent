﻿using System;
using CoreProject.Core.ValueObjects;
using FLentProject.Domain.Base.People;

namespace FLentProject.Domain.Users
{
    public class User : Person
    {
        public const int MinPasswordLength = 6;
        public const int MaxPasswordLength = 16;
        public const string UserRoleAdmin = "Admin";
        public const string UserRoleGeneral = "User";

        public Email Login { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public string Token { get; private set; }
        public string RecoveryToken { get; private set; }

        public User(string name, Email login, string password) : base(name)
        {
            Login = login;
            Password = password;
            Role = UserRoleAdmin;
            Token = Guid.NewGuid().ToString();
            RecoveryToken = Guid.NewGuid().ToString();
        }
    }
}
