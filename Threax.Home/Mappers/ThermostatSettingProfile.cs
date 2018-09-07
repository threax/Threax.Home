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
    public partial class AppMapper
    {
        public ThermostatSettingEntity MapThermostatSetting(ThermostatSettingInput src, ThermostatSettingEntity dest)
        {
            return mapper.Map(src, dest);
        }

        public ThermostatSetting MapThermostatSetting(ThermostatSettingEntity src, ThermostatSetting dest)
        {
            return mapper.Map(src, dest);
        }
    }

    public partial class ThermostatSettingProfile : Profile
    {
        public ThermostatSettingProfile()
        {
            //Map the input model to the entity
            MapInputToEntity(CreateMap<ThermostatSettingInput, ThermostatSettingEntity>());

            //Map the entity to the view model.
            MapEntityToView(CreateMap<ThermostatSettingEntity, ThermostatSetting>());
        }

        partial void MapInputToEntity(IMappingExpression<ThermostatSettingInput, ThermostatSettingEntity> mapExpr);

        partial void MapEntityToView(IMappingExpression<ThermostatSettingEntity, ThermostatSetting> mapExpr);
    }
}