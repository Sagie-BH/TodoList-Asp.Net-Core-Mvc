using AutoMapper;
using TodoList.Dtos.TodoDtos;
using System;
using System.Collections.Generic;
using System.Text;
using TodoList.ViewModels;

namespace TodoList.Profiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<TodoObjectModel, TodoObjectReadDto>();
            CreateMap<TodoObjectCreateDto, TodoObjectModel>();
            CreateMap<TodoViewModel, TodoObjectCreateDto>();
        }
    }
}
