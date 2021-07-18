using System;
using System.Collections.Generic;
using System.Text;
using ExampleMVC.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleMVC.DAL.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }

        public DataBaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ExampleMVC;Trusted_Connection=True;");
        }
    }
}
