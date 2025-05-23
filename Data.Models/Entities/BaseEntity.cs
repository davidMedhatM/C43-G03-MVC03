﻿namespace Company.Data.Entites
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
