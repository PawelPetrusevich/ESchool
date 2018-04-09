using System;
using AutoMapper;
using ESchool.Common.DTO;
using ESchool.Common.Model.Users;

namespace ESchool.Common
{
    public class MapperProfiler : Profile
    {
        public MapperProfiler()
        {
            this.CreateMap<AccauntDbModel, CreatedUserDto>().ReverseMap();

            this.CreateMap<AccauntSettingsDbModel, ModifiUserSettingsDTO>().ReverseMap();

            this.CreateMap<AccauntDbModel, UserBannedDTO>()
                .ForMember(item => item.IsBanned, x => x.MapFrom(y => y.IsBanned))
                .ForMember(item => item.UserName, x => x.MapFrom(y => y.Loggin))
                .ReverseMap();

            this.CreateMap<AccauntDbModel, UserDeletedDTO>()
                .ForMember(item => item.UserName, x => x.MapFrom(y => y.Loggin))
                .ReverseMap();
        }
    }
}