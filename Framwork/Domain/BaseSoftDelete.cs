using System;

namespace framework.Domain
{
    public class BaseSoftDelete : BaseEntity
    {
        public long? DeletedBy { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}