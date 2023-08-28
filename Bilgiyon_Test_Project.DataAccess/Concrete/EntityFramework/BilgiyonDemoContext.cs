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
            optionsBuilder.UseSqlServer(@"Server=172.16.1.120,1433;Initial Catalog=BilgiyonDemo;User Id=TEST;Password=TEST");
        }

        public DbSet<User> R5USERS { get; set; }
        public DbSet<Event> R5EVENTS { get; set; }

    }
}
