using System;
using velvetech.Infrastructure;

namespace velvetech.Models
{
    public class Student : IStudent
    {
        public Guid Id { get; set; }
        public int? Pol { get; set; }
        public string Fam { get; set; }
        public string Nam { get; set; }
        public string Oth { get; set; }
        public string Alias { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public DateTime? Removed { get; set; }
    }
}
