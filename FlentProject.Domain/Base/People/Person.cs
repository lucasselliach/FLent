using System;
using CoreProject.Core.Entities;

namespace FlentProject.Domain.Base.People
{
    public abstract class Person : Entity
    {
        public string Name { get; }
        public DateTime RegisterDate { get; }
        
        protected Person(string name)
        {
            Name = name;
            RegisterDate = DateTime.Now;
        }
    }
}
