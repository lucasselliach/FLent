using System;
using CoreProject.Core.Entities;

namespace FLentProject.Domain.Games
{
    public class Game : Entity
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 100;

        public string Name { get; }
        public DateTime RegisterDate { get; }
        public bool Lent { get; private set; }

        public Game(string name, DateTime registerDate, bool lent)
        {
            Name = name;
            RegisterDate = registerDate;
            Lent = lent;
        }

        public void Lending()
        {
            Lent = true;
        }

        public void Returning()
        {
            Lent = false;
        }
    }
}
