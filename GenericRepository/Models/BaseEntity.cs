using System;

namespace GenericRepository.Models
{
    public abstract class BaseEntity : IEntity
    {
        public BaseEntity()
        {
            CreatedTime = DateTime.Now;
            // UpdatedTime.HasValue
        }
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }


    public interface IEntity { }
}
