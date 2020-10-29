using AutoMapper;
using DAL.Dtos.UserDtos;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Profiles
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
