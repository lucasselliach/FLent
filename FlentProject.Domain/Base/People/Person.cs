using System;
using CoreProject.Core.Entities;

namespace FlentProject.Domain.Base.People
{
    public abstract class Person : Entity
    {
        public const int MinNameLength = 3;
        public const int MaxNameLength = 100;

        public string Name { get; }
        public DateTime RegisterDate { get; }
        
        protected Person(string name)
        {
            Name = name;
            RegisterDate = DateTime.Now;
        }
    }
}
