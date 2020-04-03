using System;
using EventSourcing.Domain.Core;

namespace EventSourcing.Domain.Models.Images
{
    public class Image : AggregateRoot
    {
        public string Path { get; private set; }
        public int EntityId { get; private set; }
        public string EntityName { get; private set; }

        public Image(string path, int entityId, string entityName)
        {
            Id = Guid.NewGuid();
            Path = path;
            EntityId = entityId;
            EntityName = entityName;
        }
    }
}
