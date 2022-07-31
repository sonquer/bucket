using Bucket.Domain.Interfaces.Entities;
using System;

namespace Bucket.Domain.Entities
{
    public class ClusterEntity : IEntity
    {
        public Guid Id { get; }

        public string Name { get; }

        public string FilePath { get; }

        public ClusterEntity(string name, string filePath)
        {
            Id = Guid.NewGuid();
            Name = name;
            FilePath = filePath;
        }
    }
}