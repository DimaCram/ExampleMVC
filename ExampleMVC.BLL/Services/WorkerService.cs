using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ExampleMVC.BLL.DTO;
using ExampleMVC.BLL.Interfaces;
using ExampleMVC.DAL;
using ExampleMVC.DAL.Entities;
using ExampleMVC.DAL.Interfaces;

namespace ExampleMVC.BLL.Services
{
    public class WorkerService : IWorkerService
    {
        private IUnitOfWork db;

        public WorkerService()
        {
            db = new UnitOfWork();
        }

        public void AddWorker(WorkerDTO workerDTO)
        {
            if (workerDTO == null)
                throw new ArgumentException();

            var worker = new Worker()
            {
                Id = workerDTO.Id,
                Name = workerDTO.Name,
                Surname = workerDTO.Surname,
                Age = workerDTO.Age
            };

            db.Workers.Create(worker);
            db.Save();
        }

        public void EditWorker(WorkerDTO workerDTO)
        {
            if (workerDTO == null)
                throw new ArgumentException();

            var worker = new Worker()
            {
                Id = workerDTO.Id,
                Name = workerDTO.Name,
                Surname = workerDTO.Surname,
                Age = workerDTO.Age
            };

            db.Workers.Update(worker);
            db.Save();
        }

        public void DeleteWorker(int id)
        {
            db.Workers.Delete(id);
            db.Save();
        }

        public WorkerDTO GetWorker(int id)
        {
            var worker = db.Workers.Get(id);
            return new WorkerDTO()
            {
                Id = worker.Id,
                Name = worker.Name,
                Surname = worker.Surname,
                Age = worker.Age
            };
        }

        public IEnumerable<WorkerDTO> GetWorkers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Worker, WorkerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Worker>, List<WorkerDTO>>(db.Workers.GetAll());
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
