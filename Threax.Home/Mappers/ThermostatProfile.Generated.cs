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
        partial void MapInputToEntity(IMappingExpression<ThermostatInput, ThermostatEntity> mapExpr)
        {
            mapExpr.ForMember(d => d.ThermostatId, opt => opt.Ignore())
                .ForMember(d => d.State, opt => opt.Ignore())
                .ForMember(d => d.FanState, opt => opt.Ignore())
                .ForMember(d => d.TempUnits, opt => opt.Ignore())
                .ForMember(d => d.Schedule, opt => opt.Ignore())
                .ForMember(d => d.SchedulePart, opt => opt.Ignore())
                .ForMember(d => d.Away, opt => opt.Ignore())
                .ForMember(d => d.Holidy, opt => opt.Ignore())
                .ForMember(d => d.Override, opt => opt.Ignore())
                .ForMember(d => d.OverrideTime, opt => opt.Ignore())
                .ForMember(d => d.ForceUnocc, opt => opt.Ignore())
                .ForMember(d => d.SpaceTemp, opt => opt.Ignore())
                .ForMember(d => d.CoolTempMin, opt => opt.Ignore())
                .ForMember(d => d.CoolTempMax, opt => opt.Ignore())
                .ForMember(d => d.HeatTempMin, opt => opt.Ignore())
                .ForMember(d => d.HeatTempMax, opt => opt.Ignore())
                .ForMember(d => d.SetPointDelta, opt => opt.Ignore())
                .ForMember(d => d.Humidity, opt => opt.Ignore())
                .ForMember(d => d.AvailableModes, opt => opt.Ignore())
                .ForMember(d => d.Created, opt => opt.MapFrom<ICreatedResolver>())
                .ForMember(d => d.Modified, opt => opt.MapFrom<IModifiedResolver>());
        }

        partial void MapEntityToView(IMappingExpression<ThermostatEntity, Thermostat> mapExpr)
        {
            
        }
    }
}