using System;
using CoreProject.Core.ValueObjects;
using FLentProject.Domain.Friends;
using FLentProject.Domain.Games;
using FLentProject.Domain.Lends;
using FLentProject.Domain.Users;
using Xunit;

namespace FLentProject.Domain.Test.LendTests
{
    public class LendTest
    {
        [Fact]
        public void If_game_has_been_created_then_game_id_is_a_valid_guid()
        {
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

            Assert.True(Guid.TryParse(lend.Id, out _), "Lend id is not valid!");
        }

        [Fact]
        public void If_game_has_been_created_then_game_title_is_not_empty()
        {
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

            Assert.False(string.IsNullOrEmpty(lend.Title), "Lend title is empty!");
        }
    }
}
