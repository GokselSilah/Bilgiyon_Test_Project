using Bilgiyon_Test_Project.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgiyon_Test_Project.DataAccess.Concrete.EntityFramework
{
    public class BilgiyonDemoContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=GOKSEL\MSSQLSERVER01;Database=BilgiyonDemo;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public DbSet<User> R5USERS { get; set; }
        public DbSet<Event> R5EVENTS { get; set; }

    }
}
