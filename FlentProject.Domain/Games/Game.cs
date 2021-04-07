using System;
using System.Text.Json.Serialization;
using CoreProject.Core.Entities;

namespace FLentProject.Domain.Games
{
    public class Game : Entity
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 100;

        public string Name { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public bool Lent { get; private set; }

        public Game(string name)
        {
            Name = name;
            RegisterDate = DateTime.Now;
            Lent = false;
        }

        public void Edit(string name)
        {
            Name = name;
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
