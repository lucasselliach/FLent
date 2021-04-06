using FLentProject.Domain.Games;
using FLentProject.Domain.Games.GamesValidations;
using Xunit;

namespace FLentProject.Domain.Test.GameTests
{
    public class GameValidationTest
    {
        [Fact]
        public void If_validation_has_been_checked_with_invalid_game_then_game_is_invalid()
        {
            var gameValidation = new GameValidation();
            var game = new Game("G");

            Assert.False(gameValidation.Check(game), "Game is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_valid_game_then_game_is_valid()
        {
            var gameValidation = new GameValidation();
            var game = new Game("GTA");

            Assert.True(gameValidation.Check(game), "Game is not valid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_null_game_name_then_name_is_invalid()
        {
            var gameValidation = new GameValidation();
            var game = new Game(null);

            Assert.False(gameValidation.Check(game), "Null game name is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_empty_game_name_then_name_is_invalid()
        {
            var gameValidation = new GameValidation();
            var game = new Game("");

            Assert.False(gameValidation.Check(game), "Empty game name is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_min_lenght_enough_game_name_then_name_is_invalid()
        {
            var gameValidation = new GameValidation();
            var game = new Game("P");

            Assert.False(gameValidation.Check(game), "Min game name is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_max_lenght_enough_game_name_then_name_is_invalid()
        {
            var gameValidation = new GameValidation();
            var game = new Game("IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIO");

            Assert.False(gameValidation.Check(game), "Max game name is not invalid!");
        }
    }
}
