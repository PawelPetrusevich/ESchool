﻿using System;
using AutoMapper;
using ESchool.Common.DTO;
using ESchool.Common.Model.Users;

namespace ESchool.Common
{
    public class MapperProfiler : Profile
    {
        public MapperProfiler()
        {
            this.CreateMap<AccauntDbModel, UserDTO>().ReverseMap();
        }
    }
}