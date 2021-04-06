using CoreProject.Core.ValueObjects;
using FLentProject.Domain.Friends;
using FLentProject.Domain.Friends.FriendValidations;
using FLentProject.Domain.Games;
using FLentProject.Domain.Games.GamesValidations;
using FLentProject.Domain.Lends;
using FLentProject.Domain.Lends.LendValidations;
using FLentProject.Domain.Users;
using FLentProject.Domain.Users.UserValidations;
using Xunit;

namespace FLentProject.Domain.Test.LendTests
{
    public class LendValidationTest
    {
        [Fact]
        public void If_validation_has_been_checked_with_invalid_lend_then_lend_is_invalid()
        {
            var userValidation = new UserValidation();
            var friendValidation = new FriendValidation();
            var gameValidation = new GameValidation();
            var lendValidation = new LendValidation(userValidation, friendValidation, gameValidation);
            
            var userEmail = new Email("zezinho@gmail.com");

            var user = new User("Zezinho",
                userEmail,
                "123456");

            var friendEmail = new Email("duduzinho@gmail.com");
            var friendPhone = new Phone("9999999999");

            var friend = new Friend("duduzinho",
                "dudu",
                friendEmail,
                friendPhone);

            var lend = new Lend(user, friend, null);

            Assert.False(lendValidation.Check(lend), "Lend is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_valid_lend_then_lend_is_valid()
        {
            var userValidation = new UserValidation();
            var friendValidation = new FriendValidation();
            var gameValidation = new GameValidation();
            var lendValidation = new LendValidation(userValidation, friendValidation, gameValidation);

            var userEmail = new Email("zezinho@gmail.com");

            var user = new User("Zezinho",
                userEmail,
                "123456");

            var friendEmail = new Email("duduzinho@gmail.com");
            var friendPhone = new Phone("9999999999");

            var friend = new Friend("duduzinho",
                "dudu",
                friendEmail,
                friendPhone);

            var game = new Game("Call of Duty: MW");

            var lend = new Lend(user, friend, game);

            Assert.True(lendValidation.Check(lend), "Lend is not valid! R:" + lendValidation.Notifications);
        }

        [Fact]
        public void If_validation_has_been_checked_with_invalid_user_then_lend_is_invalid()
        {
            var userValidation = new UserValidation();
            var friendValidation = new FriendValidation();
            var gameValidation = new GameValidation();
            var lendValidation = new LendValidation(userValidation, friendValidation, gameValidation);

            var userEmail = new Email("zezinho@gmail.com");

            var user = new User("Z",
                userEmail,
                "123456");

            var friendEmail = new Email("duduzinho@gmail.com");
            var friendPhone = new Phone("9999999999");

            var friend = new Friend("duduzinho",
                "dudu",
                friendEmail,
                friendPhone);

            var game = new Game("Call of Duty: MW");

            var lend = new Lend(user, friend, game);

            Assert.False(lendValidation.Check(lend), "Lend is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_invalid_friend_then_lend_is_invalid()
        {
            var userValidation = new UserValidation();
            var friendValidation = new FriendValidation();
            var gameValidation = new GameValidation();
            var lendValidation = new LendValidation(userValidation, friendValidation, gameValidation);

            var userEmail = new Email("zezinho@gmail.com");

            var user = new User("Zezinho",
                userEmail,
                "123456");

            var friendEmail = new Email("duduzinho@gmail.com");
            var friendPhone = new Phone("9999999999");

            var friend = new Friend("",
                "dudu",
                friendEmail,
                friendPhone);

            var game = new Game("Call of Duty: MW");

            var lend = new Lend(user, friend, game);

            Assert.False(lendValidation.Check(lend), "Lend is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_invalid_game_then_lend_is_invalid()
        {
            var userValidation = new UserValidation();
            var friendValidation = new FriendValidation();
            var gameValidation = new GameValidation();
            var lendValidation = new LendValidation(userValidation, friendValidation, gameValidation);

            var userEmail = new Email("zezinho@gmail.com");

            var user = new User("Zezinho",
                userEmail,
                "123456");

            var friendEmail = new Email("duduzinho@gmail.com");
            var friendPhone = new Phone("9999999999");

            var friend = new Friend("duduzinho",
                "dudu",
                friendEmail,
                friendPhone);

            var game = new Game("C");

            var lend = new Lend(user, friend, game);

            Assert.False(lendValidation.Check(lend), "Lend is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_null_user_then_lend_is_invalid()
        {
            var userValidation = new UserValidation();
            var friendValidation = new FriendValidation();
            var gameValidation = new GameValidation();
            var lendValidation = new LendValidation(userValidation, friendValidation, gameValidation);

            var friendEmail = new Email("duduzinho@gmail.com");
            var friendPhone = new Phone("9999999999");

            var friend = new Friend("duduzinho",
                "dudu",
                friendEmail,
                friendPhone);

            var game = new Game("Call of Duty: MW");

            var lend = new Lend(null, friend, game);

            Assert.False(lendValidation.Check(lend), "Lend is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_null_friend_then_lend_is_invalid()
        {
            var userValidation = new UserValidation();
            var friendValidation = new FriendValidation();
            var gameValidation = new GameValidation();
            var lendValidation = new LendValidation(userValidation, friendValidation, gameValidation);

            var userEmail = new Email("zezinho@gmail.com");

            var user = new User("Zezinho",
                userEmail,
                "123456");

            var game = new Game("Call of Duty: MW");

            var lend = new Lend(user, null, game);

            Assert.False(lendValidation.Check(lend), "Lend is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_null_game_then_lend_is_invalid()
        {
            var userValidation = new UserValidation();
            var friendValidation = new FriendValidation();
            var gameValidation = new GameValidation();
            var lendValidation = new LendValidation(userValidation, friendValidation, gameValidation);

            var userEmail = new Email("zezinho@gmail.com");

            var user = new User("Zezinho",
                userEmail,
                "123456");

            var friendEmail = new Email("duduzinho@gmail.com");
            var friendPhone = new Phone("9999999999");

            var friend = new Friend("duduzinho",
                "dudu",
                friendEmail,
                friendPhone);

            var lend = new Lend(user, friend, null);

            Assert.False(lendValidation.Check(lend), "Lend is not invalid!");
        }

        //[Fact]
        //public void If_validation_has_been_checked_with_invalid_user_then_lend_is_invalid()
        //{
        //    var userValidation = new UserValidation();
        //    var friendValidation = new FriendValidation();
        //    var gameValidation = new GameValidation();
        //    var lendValidation = new LendValidation(userValidation, friendValidation, gameValidation);

        //    var userEmail = new Email("zezinho@gmail.com");

        //    var user = new User("Zezinho",
        //        userEmail,
        //        "123456");

        //    var friendEmail = new Email("duduzinho@gmail.com");
        //    var friendPhone = new Phone("9999999999");

        //    var friend = new Friend("duduzinho",
        //        "dudu",
        //        friendEmail,
        //        friendPhone);

        //    var game = new Game("Call of Duty: MW");

        //    var lend = new Lend(user, friend, game);

        //    Assert.False(lendValidation.Check(lend), "Lend is not invalid!");
        //}
    }
}
