using System;
using System.Collections.Generic;
using System.Text;
using ExampleMVC.DAL.Context;
using ExampleMVC.DAL.Entities;
using ExampleMVC.DAL.Interfaces;
using ExampleMVC.DAL.Repositories;

namespace ExampleMVC.DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DataBaseContext db;

        private WorkerRepository workerRepository;

        public UnitOfWork()
        {
            db = new DataBaseContext();
        }

        public IRepository<Worker> Workers
        {
            get
            {
                if (workerRepository == null)
                    workerRepository = new WorkerRepository(db);

                return workerRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
