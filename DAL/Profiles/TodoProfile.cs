using AutoMapper;
using DAL.Dtos.TodoDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Profiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<TodoObjectModel, TodoObjectReadDto>();
            CreateMap<TodoObjectCreateDto, TodoObjectModel>();
        }
    }
}
