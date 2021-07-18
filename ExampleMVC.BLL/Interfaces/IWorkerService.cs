using System;
using System.Collections.Generic;
using System.Text;
using ExampleMVC.BLL.DTO;

namespace ExampleMVC.BLL.Interfaces
{
    public interface IWorkerService
    {
        void AddWorker(WorkerDTO workerDTO);
        void EditWorker(WorkerDTO workerDTO);
        void DeleteWorker(int id);
        WorkerDTO GetWorker(int id);
        IEnumerable<WorkerDTO> GetWorkers();
        void Dispose();
    }
}
