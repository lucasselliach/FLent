﻿using System;
using CoreProject.Core.Entities;
using FLentProject.Domain.Friends;
using FLentProject.Domain.Games;
using FLentProject.Domain.Users;

namespace FLentProject.Domain.Lends
{
    public class Lend : Entity
    {
        public string Title { get; private set; }
        public User User { get; private set; }
        public Friend Friend { get; private set; }
        public Game Game { get; private set; }
        public DateTime LendingDate { get; private set; }
        public DateTime DeadlineDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public bool Active { get; private set; }

        public Lend(User user, Friend friend, Game game)
        {
            Title = "Empréstimo de " + game?.Name + " para " + friend?.Name;
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
