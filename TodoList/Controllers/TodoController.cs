using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Dtos;
using DAL.Models;
using DAL.Repositories;
using DAL.ViewModels;
using Microsoft.AspNetCore.Http;
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
        public ActionResult TodoFormTask(TodoViewModel todoViewObject)
        {
            var TodoModelObject = _mapper.Map<TodoObjectModel>(todoViewObject);
            _sqlRepository.Create(TodoModelObject);

            if(_sqlRepository.SaveChanges())
            {
                return Ok(_mapper.Map<TodoViewModel>(TodoModelObject));
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<TodoViewModel> Delete(int id)
        {
            try
            {
                var todoToDelete =  _sqlRepository.GetById(id);
                if (todoToDelete == null)
                {
                    return NotFound($"Todo Object with Id = {id} not found");
                }
                _sqlRepository.Remove(id);
                _sqlRepository.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }


        [HttpPost]
        public ActionResult<TodoObjectCreateDto> Edit([FromBody] TodoObjectCreateDto todoViewObject)
        {
            var a = todoViewObject;
            return Json(a);
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
