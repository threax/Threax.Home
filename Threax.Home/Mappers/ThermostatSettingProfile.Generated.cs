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
    public partial class ThermostatSettingProfile : Profile
    {
        partial void MapInputToEntity(IMappingExpression<ThermostatSettingInput, ThermostatSettingEntity> mapExpr)
        {
            mapExpr.ForMember(d => d.ThermostatSettingId, opt => opt.Ignore())
                .ForMember(d => d.Created, opt => opt.ResolveUsing<ICreatedResolver>())
                .ForMember(d => d.Modified, opt => opt.ResolveUsing<IModifiedResolver>());
        }

        partial void MapEntityToView(IMappingExpression<ThermostatSettingEntity, ThermostatSetting> mapExpr)
        {
            
        }
    }
}