using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Honeywell.CodeExercise.Model;
using Entities;

namespace Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
        }
    }
}
