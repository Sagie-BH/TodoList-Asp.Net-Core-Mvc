using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using DAL.Dtos.UserDtos;

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
