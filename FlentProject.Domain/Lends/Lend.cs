using System;
using CoreProject.Core.Entities;
using FlentProject.Domain.Friends;
using FlentProject.Domain.Games;
using FlentProject.Domain.Users;

namespace FlentProject.Domain.Lends
{
    public class Lend : Entity
    {
        public string Title { get; }
        public User User { get; }
        public Friend Friend { get; }
        public Game Game { get; }
        public DateTime LendingDate { get; private set; }
        public DateTime DeadlineDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public bool Active { get; private set; }

        public Lend(User user, Friend friend, Game game)
        {
            Title = "";
            User = user;
            Friend = friend;
            Game = game;
        }

        public void Lending(DateTime deadlineDate)
        {
            LendingDate = DateTime.Today;
            DeadlineDate = deadlineDate;
            Active = true;
            
            Game.Lending();
        }

        public void Returning()
        {
            ReturnDate = DateTime.Today;
            Active = false;

            Game.Returning();
        }
    }
}
