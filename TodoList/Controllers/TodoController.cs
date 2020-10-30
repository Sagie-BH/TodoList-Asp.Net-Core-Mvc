using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TodoList;
using TodoList.Dtos.TodoDtos;
using TodoList.Repositories;
using TodoList.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class TodoController : Controller
    {
        private readonly ILogger<TodoController> _logger;
        private readonly ISqlRepository<TodoObjectModel> _sqlRepository;
        private readonly IMapper _mapper;

        public TodoController(ILogger<TodoController> logger, ISqlRepository<TodoObjectModel> sqlRepository, IMapper mapper)
        {
            _logger = logger;
            _sqlRepository = sqlRepository;
            _mapper = mapper;
        }

        public IActionResult Todo()
        {
            return View();
        }
        public IActionResult TodoList()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult TodoFormTask(TodoObjectCreateDto todoCreateObject)
        {
            var TodoModelObject = _mapper.Map<TodoObjectModel>(todoCreateObject);
            _sqlRepository.Create(TodoModelObject);
            if(_sqlRepository.SaveChanges())
            {
                return View("Todo");
            }
            return NotFound();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
