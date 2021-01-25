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
    public partial class ThermostatProfile : Profile
    {
        public ThermostatProfile()
        {
            //Map the input model to the entity
            MapInputToEntity(CreateMap<ThermostatInput, ThermostatEntity>());

            //Map the entity to the view model.
            MapEntityToView(CreateMap<ThermostatEntity, Thermostat>());

            CreateMap<Thermostat, ThermostatEntity>()
                .ForMember(d => d.ThermostatId, opt => opt.Ignore())
                .ForMember(d => d.Created, opt => opt.MapFrom<ICreatedResolver>())
                .ForMember(d => d.Modified, opt => opt.MapFrom<IModifiedResolver>());

            CreateMap<Thermostat, ThermostatInput>();
        }

        partial void MapInputToEntity(IMappingExpression<ThermostatInput, ThermostatEntity> mapExpr);

        partial void MapEntityToView(IMappingExpression<ThermostatEntity, Thermostat> mapExpr);
    }
}