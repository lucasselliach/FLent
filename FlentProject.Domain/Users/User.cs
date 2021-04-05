using System;
using CoreProject.Core.ValueObjects;
using FlentProject.Domain.Base.People;

namespace FlentProject.Domain.Users
{
    public class User : Person
    {
        public Email Login { get; }
        public string Password { get; }
        public string Role { get; }
        public string Token { get; }
        public string RecoveryToken { get; }

        public User(string name, Email login, string password) : base(name)
        {
            Login = login;
            Password = password;
            Role = "Admin";
            Token = Guid.NewGuid().ToString();
            RecoveryToken = Guid.NewGuid().ToString();
        }
    }
}
