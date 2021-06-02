using System;

namespace _DomainUtils.Domain
{
    public class BaseEntity<TKey>
    {
        public void Delete()
        {
            IsDelete = true;
            DeleteDate = DateTime.Now;
        }
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
        }
        public TKey Id { get; set; }
        public DateTime CreationDate { get; }
        public DateTime ModifyDate { get; protected set; }
        public bool IsDelete { get; protected set; }
        public DateTime DeleteDate { get; protected set; }
    }
    public class BaseEntity
    {
        public void Delete()
        {
            IsDelete = true;
            DeleteDate = DateTime.Now;
        }
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public DateTime CreationDate { get; }
        public DateTime ModifyDate { get; protected set; }
        public bool IsDelete { get; protected set; }
        public DateTime DeleteDate { get; protected set; }
    }
}
