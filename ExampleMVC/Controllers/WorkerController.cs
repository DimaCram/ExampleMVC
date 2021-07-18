using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExampleMVC.BLL.DTO;
using ExampleMVC.BLL.Interfaces;
using ExampleMVC.BLL.Services;
using ExampleMVC.Models;

namespace ExampleMVC.Controllers
{
    public class WorkerController : Controller
    {
        private readonly IWorkerService workerService;
        public WorkerController()
        {
            workerService = new WorkerService();
        }

        public IActionResult Index()
        {
            var workerDtos = workerService.GetWorkers();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<WorkerDTO, WorkerModel>()).CreateMapper();
            var workers = mapper.Map<IEnumerable<WorkerDTO>, List<WorkerModel>>(workerDtos);

            return View(workers);
        }

        [HttpGet]
        public IActionResult AddWorker()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWorker(WorkerModel worker)
        {
            workerService.AddWorker(new WorkerDTO()
            {
                Name = worker.Name,
                Surname = worker.Surname,
                Age = worker.Age
            });

            return RedirectToAction("Index", "Worker");
        }

        [HttpGet]
        public IActionResult EditWorker(int id)
        {
            var workerDto = workerService.GetWorker(id);

            var worker = new WorkerModel()
            {
                Id = workerDto.Id,
                Name = workerDto.Name,
                Surname = workerDto.Surname,
                Age = workerDto.Age
            };
            return View(worker);
        }

        [HttpPost]
        public IActionResult EditWorker(WorkerModel worker)
        {
            workerService.EditWorker(new WorkerDTO()
            {
                Id = worker.Id,
                Name = worker.Name,
                Surname = worker.Surname,
                Age = worker.Age
            });

            return RedirectToAction("Index", "Worker");
        }

        [HttpGet]
        public IActionResult DeleteWorker(int id)
        {
            workerService.DeleteWorker(id);
            return RedirectToAction("Index", "Worker");
        }
    }
}
