using DAL.Dtos;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ViewModels.TodoViewModels
{
    public class TodoListViewModel
    {
        public TodoObjectViewModel TodoObject { get; set; }
        public List<TodoObjectViewModel> TodoList { get; set; }
        public TodoSearchDto SearchDto { get; set; }
        public string UserEmail { get; set; }
    }
}
