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
using Microsoft.Extensions.Logging;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class TodoController : Controller
    {
        private readonly ILogger<TodoController> _logger;
        private readonly IRepository<TodoObjectModel> repository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public TodoController(ILogger<TodoController> logger, IRepository<TodoObjectModel> repository,
                        IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            this.repository = repository;
            _mapper = mapper;
            this.userManager = userManager;
        }

        public IActionResult Todo(ApplicationUser user)
        {
            var todoList = repository.GetAll().Where(x => x.UserEmail == user.Email);

            TodoListViewModel model = new TodoListViewModel
            {
                TodoList = _mapper.Map<IEnumerable<TodoObjectViewModel>>(todoList).ToList(),
                UserEmail = user.Email
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTodo(TodoObjectViewModel todoObject, string userEmail)
        {
            var todoModelObject = _mapper.Map<TodoObjectModel>(todoObject);

            //var user = await userManager.FindByEmailAsync(userEmail);

            todoModelObject.UserEmail = userEmail;

            repository.Create(todoModelObject);

            if (await repository.SaveChanges())
            {
                return RedirectToAction("Todo", new ApplicationUser { Email = userEmail });
            }
            return base.NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<TodoObjectViewModel>> Delete(int id)
        {
            try
            {
                var todoToDelete = repository.GetById(id);
                if (todoToDelete == null)
                {
                    return NotFound($"Todo Object with Id = {id} not found");
                }
                repository.Remove(id);
                if (await repository.SaveChanges())
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
                var TodoList = repository.GetAll().Where(x => x.GetType().GetProperty(searchObj.Property).GetValue(x).ToString().StartsWith(searchObj.SearchTerm)).ToList();

                var viewlist = _mapper.Map<IEnumerable<TodoObjectReadDto>>(TodoList);

                return Json(viewlist);
            }
            else return Json(repository.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromBody]TodoObjectCreateDto todoData)
        {
            var todoToEdit = repository.GetById(todoData.Id);
            var user = await userManager.FindByEmailAsync(todoData.UserEmail);

            todoToEdit.UserEmail = user.Id;
            _mapper.Map(todoData, todoToEdit);

            repository.Update(todoToEdit);

            if (await repository.SaveChanges())
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
