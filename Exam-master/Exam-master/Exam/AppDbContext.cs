using Exam.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class AppDbContext : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<Request> Requests { get; set; }
            public DbSet<Comment> Comments { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=MY_PC;Initial Catalog=DemoEx;Integrated Security=True;Trust Server Certificate=True");
            }
        }
    
}
