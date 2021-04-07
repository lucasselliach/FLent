using System;
using CoreProject.Core.Entities;

namespace FLentProject.Domain.Base.People
{
    public abstract class Person : Entity
    {
        public const int MinNameLength = 3;
        public const int MaxNameLength = 100;

        public string Name { get; private set; }
        public DateTime RegisterDate { get; private set; }

        protected Person(string name)
        {
            Name = name;
            RegisterDate = DateTime.Now;
        }
    }
}
