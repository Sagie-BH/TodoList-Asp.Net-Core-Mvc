using DAL.Dtos.TodoDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.ViewModels
{
    public class TodoViewModel
    {
        public TodoObjectReadDto TodoObject { get; set; }
        public List<TodoObjectReadDto> TodoList {get;set;}
    }
}
