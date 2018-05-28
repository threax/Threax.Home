using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Tracking;
using Threax.Home.InputModels;
using Threax.Home.Database;
using Threax.Home.ViewModels;
using Threax.Home.Core;

namespace Threax.Home.Mappers
{
    public partial class SensorProfile : Profile
    {
        partial void MapInputToEntity(IMappingExpression<SensorInput, SensorEntity> mapExpr)
        {
            mapExpr.ForMember(d => d.SensorId, opt => opt.Ignore())
                .ForMember(d => d.Created, opt => opt.ResolveUsing<ICreatedResolver>())
                .ForMember(d => d.Modified, opt => opt.ResolveUsing<IModifiedResolver>());
        }

        partial void MapEntityToView(IMappingExpression<SensorEntity, Sensor> mapExpr)
        {
            
        }
    }
}