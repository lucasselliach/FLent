using System;
using CoreProject.Core.ValueObjects;
using FLentProject.Domain.Friends;
using FLentProject.Domain.Games;
using FLentProject.Domain.Lends;
using Xunit;

namespace FLentProject.Domain.Test.LendTests
{
    public class LendTest
    {
        [Fact]
        public void If_game_has_been_created_then_game_id_is_a_valid_guid()
        {
            var userId = "9630b29b-c133-4d80-b4d6-e86291bb1886";

            var friendEmail = new Email("duduzinho@gmail.com");
            var friendPhone = new Phone("9999999999");

            var friend = new Friend("duduzinho",
                                    "dudu",
                                    friendEmail,
                                    friendPhone, 
                                    userId);

            var game = new Game("Call of Duty: MW", userId);

            var lend = new Lend(friend, game, userId);

            Assert.True(Guid.TryParse(lend.Id, out _), "Lend id is not valid!");
        }

        [Fact]
        public void If_game_has_been_created_then_game_title_is_not_empty()
        {
            var userId = "9630b29b-c133-4d80-b4d6-e86291bb1886";

            var friendEmail = new Email("duduzinho@gmail.com");
            var friendPhone = new Phone("9999999999");

            var friend = new Friend("duduzinho",
                                    "dudu",
                                    friendEmail,
                                    friendPhone, 
                                    userId);

            var game = new Game("Call of Duty: MW", userId);

            var lend = new Lend(friend, game, userId);

            Assert.False(string.IsNullOrEmpty(lend.Title), "Lend title is empty!");
        }
    }
}
