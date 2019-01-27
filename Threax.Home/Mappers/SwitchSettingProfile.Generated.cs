using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Tracking;
using Threax.Home.InputModels;
using Threax.Home.Database;
using Threax.Home.ViewModels;

namespace Threax.Home.Mappers
{
    public partial class SwitchSettingProfile : Profile
    {
        partial void MapInputToEntity(IMappingExpression<SwitchSettingInput, SwitchSettingEntity> mapExpr)
        {
            mapExpr.ForMember(d => d.SwitchSettingId, opt => opt.Ignore())
                .ForMember(d => d.Created, opt => opt.MapFrom<ICreatedResolver>())
                .ForMember(d => d.Modified, opt => opt.MapFrom<IModifiedResolver>());
        }

        partial void MapEntityToView(IMappingExpression<SwitchSettingEntity, SwitchSetting> mapExpr)
        {
            
        }
    }
}