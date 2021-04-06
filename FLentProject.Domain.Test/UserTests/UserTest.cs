using System;
using CoreProject.Core.ValueObjects;
using FLentProject.Domain.Users;
using Xunit;

namespace FLentProject.Domain.Test.UserTests
{
    public class UserTest
    {
        [Fact]
        public void If_user_has_been_created_then_user_id_is_a_valid_guid()
        {
            var email = new Email("zezinho@gmail.com");

            var user = new User("Zezinho",
                                email,
                                "123456");

            Assert.True(Guid.TryParse(user.Id, out _), "User id is not valid!");
        }

        [Fact]
        public void If_user_has_been_created_then_user_name_is_not_empty()
        {
            var email = new Email("zezinho@gmail.com");

            var user = new User("Zezinho",
                                email,
                                "123456");

            Assert.False(string.IsNullOrEmpty(user.Name), "User name is empty!");
        }

        [Fact]
        public void If_user_has_been_created_then_user_role_is_admin()
        {
            var email = new Email("zezinho@gmail.com");

            var user = new User("Zezinho",
                email,
                "123456");

            Assert.True(user.Role == User.UserRoleAdmin, "User role is not valid!");
        }
    }
}
