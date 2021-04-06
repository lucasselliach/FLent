using CoreProject.Core.ValueObjects;
using FLentProject.Domain.Users;
using FLentProject.Domain.Users.UserValidations;
using Xunit;

namespace FLentProject.Domain.Test.UserTests
{
    public class UserValidationTest
    {
        [Fact]
        public void If_validation_has_been_checked_with_invalid_user_then_user_is_invalid()
        {
            var userValidation = new UserValidation();

            var email = new Email("zezinho@gmail.com");

            var user = new User(null,
                email,
                "123456");

            Assert.False(userValidation.Check(user), "User is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_valid_user_then_user_is_valid()
        {
            var userValidation = new UserValidation();

            var email = new Email("zezinho@gmail.com");

            var user = new User("Zezinho",
                email,
                "123456");

            Assert.True(userValidation.Check(user), "User is not valid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_null_user_name_then_name_is_invalid()
        {
            var userValidation = new UserValidation();

            var email = new Email("zezinho@gmail.com");

            var user = new User(null,
                email,
                "123456");

            Assert.False(userValidation.Check(user), "Null user name is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_empty_user_name_then_name_is_invalid()
        {
            var userValidation = new UserValidation();

            var email = new Email("zezinho@gmail.com");

            var user = new User("",
                email,
                "123456");

            Assert.False(userValidation.Check(user), "Empty user name is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_min_lenght_enough_user_name_then_name_is_invalid()
        {
            var userValidation = new UserValidation();

            var email = new Email("zezinho@gmail.com");

            var user = new User("Ze",
                email,
                "123456");

            Assert.False(userValidation.Check(user), "Min user name is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_max_lenght_enough_user_name_then_name_is_invalid()
        {
            var userValidation = new UserValidation();

            var email = new Email("zezinho@gmail.com");

            var user = new User("IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIO",
                email,
                "123456");

            Assert.False(userValidation.Check(user), "Max user name is not invalid!");
        }
        
        [Fact]
        public void If_validation_has_been_checked_with_null_user_login_then_login_is_invalid()
        {
            var userValidation = new UserValidation();

            var email = new Email(null);

            var user = new User("Zezinho",
                email,
                "123456");

            Assert.False(userValidation.Check(user), "Null user login is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_empty_user_login_then_login_is_invalid()
        {
            var userValidation = new UserValidation();

            var email = new Email("");

            var user = new User("Zezinho",
                email,
                "123456");

            Assert.False(userValidation.Check(user), "Empty user login is not invalid!");
        }
        
        [Fact]
        public void If_validation_has_been_checked_with_max_lenght_enough_user_login_then_login_is_invalid()
        {
            var userValidation = new UserValidation();

            var email = new Email("mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm@mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm.com");

            var user = new User("Zezinho",
                email,
                "123456");

            Assert.False(userValidation.Check(user), "Max user login is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_invalid_user_login_then_login_is_invalid()
        {
            var userValidation = new UserValidation();

            var email = new Email("zezinho.com");

            var user = new User("Zezinho",
                email,
                "123456");

            Assert.False(userValidation.Check(user), "User login is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_null_user_password_then_password_is_invalid()
        {
            var userValidation = new UserValidation();

            var email = new Email("zezinho@gmail.com");

            var user = new User("Zezinho",
                email,
                null);

            Assert.False(userValidation.Check(user), "Null user password is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_empty_user_password_then_password_is_invalid()
        {
            var userValidation = new UserValidation();

            var email = new Email("zezinho@gmail.com");

            var user = new User("Zezinho",
                email,
                "");

            Assert.False(userValidation.Check(user), "Empty user password is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_min_lenght_enough_user_password_then_password_is_invalid()
        {
            var userValidation = new UserValidation();

            var email = new Email("zezinho@gmail.com");

            var user = new User("Zezinho",
                email,
                "1");

            Assert.False(userValidation.Check(user), "Min user password is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_max_lenght_enough_user_password_then_password_is_invalid()
        {
            var userValidation = new UserValidation();

            var email = new Email("zezinho@gmail.com");

            var user = new User("Zezinho",
                email,
                "12345678901234567890");

            Assert.False(userValidation.Check(user), "Max user password is not invalid!");
        }
    }
}
