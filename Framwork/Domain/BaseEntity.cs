﻿using System;

namespace framework.Domain
{
    public class BaseEntity
    {
        //public BaseEntity()
        //{
        //    CreationDate = DateTime.Now;
        //    Id = Guid.NewGuid();
        //}
        public long Id { get; set; }
        public DateTime CreationDate { get; }
        public DateTime ModifyDate { get; protected set; }
    }
}
