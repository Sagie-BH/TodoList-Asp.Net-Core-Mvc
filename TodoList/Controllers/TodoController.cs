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
using DAL.ViewModels.TodoViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class TodoController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<TodoController> _logger;
        private readonly IRepository<TodoObjectModel> _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public TodoController(ILogger<TodoController> logger, IRepository<TodoObjectModel> repository,
                        IMapper mapper, UserManager<ApplicationUser> userManager, IMemoryCache cache)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _cache = cache;
        }

        public IActionResult Todo(ApplicationUser user)
        {
            IEnumerable<TodoObjectModel> todoList;
            TodoListViewModel model = new TodoListViewModel { UserEmail = user.Email };

            if (!_cache.TryGetValue("TodoList", out todoList))
            {
                if (todoList == null)
                {
                    todoList = _repository.GetAll().Where(x => x.UserEmail == user.Email);
                    _cache.Set("TodoList", todoList);
                }
            }

            model.TodoList = _mapper.Map<IEnumerable<TodoObjectViewModel>>(todoList).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTodo(TodoObjectViewModel todoObject, string userEmail)
        {
            var todoModelObject = _mapper.Map<TodoObjectModel>(todoObject);

            todoModelObject.UserEmail = userEmail;

            _repository.Create(todoModelObject);

            if (await _repository.SaveChanges())
            {
                return RedirectToAction("Todo", new ApplicationUser { Email = userEmail });
            }
            return base.NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<TodoObjectViewModel>> Delete(int id)
        {
            try
            {
                var todoToDelete = _repository.GetById(id);
                if (todoToDelete == null)
                {
                    return NotFound($"Todo Object with Id = {id} not found");
                }
                _repository.Remove(id);
                if (await _repository.SaveChanges())
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
        public JsonResult Search(TodoSearchDto searchObj)
        {
            if (!string.IsNullOrEmpty(searchObj.SearchTerm))
            {
                var TodoList = _repository.GetAll().Where(x => x.GetType().GetProperty(searchObj.Property).GetValue(x).ToString().StartsWith(searchObj.SearchTerm)).ToList();

                var viewlist = _mapper.Map<IEnumerable<TodoObjectReadDto>>(TodoList);

                return Json(viewlist);
            }
            else return Json(_repository.GetAll());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromBody]TodoObjectCreateDto todoData)
        {
            var todoToEdit = _repository.GetById(todoData.Id);
            var user = await _userManager.FindByEmailAsync(todoData.UserEmail);

            todoToEdit.UserEmail = user.Id;
            _mapper.Map(todoData, todoToEdit);

            _repository.Update(todoToEdit);

            if (await _repository.SaveChanges())
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
