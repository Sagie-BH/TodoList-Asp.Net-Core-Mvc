using AutoMapper;
using DAL.Dtos;
using DAL.Models;
using DAL.ViewModels;

namespace DAL.Profiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<TodoObjectModel, TodoObjectReadDto>();
            CreateMap<TodoObjectCreateDto, TodoObjectModel>();
            CreateMap<TodoViewModel, TodoObjectModel>();
            CreateMap<TodoObjectModel, TodoViewModel>();

        }
    }
}
