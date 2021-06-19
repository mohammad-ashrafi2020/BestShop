using System;

namespace Common.Domain.Domain
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreationDate { get; }
        public bool IsDelete { get; protected set; }
        public DateTime? ModifyDate { get; protected set; }
        public DateTime? DeleteDate { get; protected set; }

        public void Delete()
        {
            IsDelete = true;
            DeleteDate = DateTime.Now;
        }
        public void Recovery()
        {
            IsDelete = false;
        }
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
            IsDelete = false;
        }
    }
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsDelete { get; protected set; }
        public DateTime CreationDate { get; }
        public DateTime? ModifyDate { get; protected set; }
        public DateTime? DeleteDate { get; private set; }


        public void Delete()
        {
            IsDelete = true;
            DeleteDate = DateTime.Now;
        }
        public void Recovery()
        {
            IsDelete = false;
        }
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
            Id = Guid.NewGuid();
            IsDelete = false;
        }
    }
}
