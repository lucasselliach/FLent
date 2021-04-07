using System;
using FLentProject.Domain.Games;
using Xunit;

namespace FLentProject.Domain.Test.GameTests
{
    public class GameTest
    {
        [Fact]
        public void If_game_has_been_created_then_game_id_is_a_valid_guid()
        {
            var userId = "9630b29b-c133-4d80-b4d6-e86291bb1886";
            var game = new Game("Call of Duty: MW", userId);

            Assert.True(Guid.TryParse(game.Id, out _), "Game id is not valid!");
        }

        [Fact]
        public void If_game_has_been_created_then_game_Lent_is_false()
        {
            var userId = "9630b29b-c133-4d80-b4d6-e86291bb1886";
            var game = new Game("Call of Duty: MW", userId);

            Assert.False(game.Lent, "Game Lent is not false!");
        }
    }
}
