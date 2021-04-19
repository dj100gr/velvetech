using System;

namespace velvetech.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public int Pol { get; set; }
        public string Fam { get; set; }
        public string Nam { get; set; }
        public string Oth { get; set; }
        public string Alias { get; set; }
    }
}
