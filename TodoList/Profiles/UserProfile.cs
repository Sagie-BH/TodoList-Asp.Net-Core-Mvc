using AutoMapper;
using TodoList.Dtos.UserDtos;
using TodoList.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, UserCreateDto>();
            CreateMap<UserCreateDto, UserModel>();
        }
    }
}
