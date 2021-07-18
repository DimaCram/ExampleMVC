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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().HasData(
                new Worker[]
                {
                    new Worker { Id=1, Name="Dima", Surname = "Kramkov", Age=23},
                    new Worker { Id=2, Name="Max", Surname = "Payne", Age=30},
                    new Worker { Id=3, Name="Dora", Surname = "Explorer", Age=15}
                });
        }
    }
}
