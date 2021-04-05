using System;

namespace CoreProject.Core.Entities
{
    public abstract class Entity
    {
        public string Id { get; }

        protected Entity()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
