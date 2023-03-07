﻿namespace SMS_MVCDTO.Models.Entities
{
    public abstract class BaseEntity
    {
        public string Id;
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        //public int Id
        //{
        //    get { return id; }
        //    set { id = 100; }
        //}
        //public string Id
        //{
        //    get { return id; }
        //    set { id = Guid.NewGuid().ToString(); }
        //}
    }
}
