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
    public partial class SwitchProfile : Profile
    {
        partial void MapInputToEntity(IMappingExpression<SwitchInput, SwitchEntity> mapExpr)
        {
            mapExpr.ForMember(d => d.SwitchId, opt => opt.Ignore())
                .ForMember(d => d.Subsystem, opt => opt.Ignore())
                .ForMember(d => d.Bridge, opt => opt.Ignore())
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Created, opt => opt.ResolveUsing<ICreatedResolver>())
                .ForMember(d => d.Modified, opt => opt.ResolveUsing<IModifiedResolver>());
        }

        partial void MapEntityToView(IMappingExpression<SwitchEntity, Switch> mapExpr)
        {
            
        }
    }
}