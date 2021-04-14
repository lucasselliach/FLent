using System;
using CoreProject.Core.Entities;
using FLentProject.Domain.Friends;
using FLentProject.Domain.Games;
using FLentProject.Domain.Users;

namespace FLentProject.Domain.Lends
{
    public class Lend : Entity
    {
        public string Title { get; private set; }
        public Friend Friend { get; private set; }
        public Game Game { get; private set; }
        public DateTime LendingDate { get; private set; }
        public DateTime DeadlineDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public bool Active { get; private set; }
        public string UserId { get; private set; }


        public Lend(Friend friend, Game game, string userId)
        {
            Title = "Empréstimo de " + game?.Name + " para " + friend?.Name;
            Friend = friend;
            Game = game;
            UserId = userId;
        }

        public void Lending(DateTime deadlineDate)
        {
            Game.Lending();

            LendingDate = DateTime.Today;
            DeadlineDate = deadlineDate;
            Active = true;
        }

        public void Returning()
        {
            Game.Returning();

            ReturnDate = DateTime.Today;
            Active = false;
        }
    }
}
