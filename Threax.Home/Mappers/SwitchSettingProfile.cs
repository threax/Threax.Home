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
        public SwitchSettingEntity MapSwitchSetting(SwitchSettingInput src, SwitchSettingEntity dest)
        {
            return mapper.Map(src, dest);
        }

        public SwitchSetting MapSwitchSetting(SwitchSettingEntity src, SwitchSetting dest)
        {
            return mapper.Map(src, dest);
        }
    }

    public partial class SwitchSettingProfile : Profile
    {
        public SwitchSettingProfile()
        {
            //Map the input model to the entity
            MapInputToEntity(CreateMap<SwitchSettingInput, SwitchSettingEntity>());

            //Map the entity to the view model.
            MapEntityToView(CreateMap<SwitchSettingEntity, SwitchSetting>());
        }

        partial void MapInputToEntity(IMappingExpression<SwitchSettingInput, SwitchSettingEntity> mapExpr);

        partial void MapEntityToView(IMappingExpression<SwitchSettingEntity, SwitchSetting> mapExpr);
    }
}