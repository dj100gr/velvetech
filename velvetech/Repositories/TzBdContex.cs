using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using velvetech.Models;

namespace velvetech.Repositories
{
    public class TzBdContex : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\PROG\velvetech.db");

    }
}