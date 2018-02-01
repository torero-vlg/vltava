﻿using AutoMapper;
using Db.Dto;
using T034.ViewModel;

namespace T034.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDto, RoleViewModel>()
                .ForMember(vm => vm.Selected, v => v.UseValue(true));
            CreateMap<RoleViewModel, RoleDto>();
        }
    }
}