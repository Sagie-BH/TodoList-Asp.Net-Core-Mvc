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

        [HttpPost]
        public async Task<ActionResult> TodoFormTask(TodoViewModel todoViewObject)
        {
            var TodoModelObject = _mapper.Map<TodoObjectModel>(todoViewObject);
            _sqlRepository.Create(TodoModelObject);


            if (await _sqlRepository.SaveChanges())
            {
                return Ok(_mapper.Map<TodoViewModel>(TodoModelObject));
            }
            return base.NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<TodoViewModel>> Delete(int id)
        {
            try
            {
                var todoToDelete = _sqlRepository.GetById(id);
                if (todoToDelete == null)
                {
                    return NotFound($"Todo Object with Id = {id} not found");
                }
                _sqlRepository.Remove(id);
                if (await _sqlRepository.SaveChanges())
                    return Ok();
                else return base.NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpPost]
        public JsonResult Search(SearchDto searchObj)
        {
            if (!string.IsNullOrEmpty(searchObj.SearchTerm))
            {
                var TodoList = _sqlRepository.GetAll().Where(x => x.GetType().GetProperty(searchObj.Property).GetValue(x).ToString().StartsWith(searchObj.SearchTerm)).ToList();

                var viewlist = _mapper.Map<IEnumerable<TodoObjectReadDto>>(TodoList);

                return Json(viewlist);
            }
            else return Json(_sqlRepository.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<TodoObjectCreateDto>> Edit([FromBody] TodoObjectCreateDto todoCreateObject)
        {
            var todoToEdit = _sqlRepository.GetById(todoCreateObject.Id);

            _mapper.Map(todoCreateObject, todoToEdit);

            _sqlRepository.Update(todoToEdit);

            if (await _sqlRepository.SaveChanges())
            {
                return NoContent();
            }
            return base.NotFound();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult NotFound()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

    }
}
