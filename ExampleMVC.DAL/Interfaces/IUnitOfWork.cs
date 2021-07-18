using System;
using System.Collections.Generic;
using System.Text;
using ExampleMVC.DAL.Entities;

namespace ExampleMVC.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Worker> Workers { get; }
        void Save();
    }
}
