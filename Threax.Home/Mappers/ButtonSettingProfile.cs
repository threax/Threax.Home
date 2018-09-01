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
        public ButtonSettingEntity MapButtonSetting(ButtonSettingInput src, ButtonSettingEntity dest)
        {
            return mapper.Map(src, dest);
        }

        public ButtonSetting MapButtonSetting(ButtonSettingEntity src, ButtonSetting dest)
        {
            return mapper.Map(src, dest);
        }
    }

    public partial class ButtonSettingProfile : Profile
    {
        public ButtonSettingProfile()
        {
            //Map the input model to the entity
            MapInputToEntity(CreateMap<ButtonSettingInput, ButtonSettingEntity>());

            //Map the entity to the view model.
            MapEntityToView(CreateMap<ButtonSettingEntity, ButtonSetting>());
        }

        partial void MapInputToEntity(IMappingExpression<ButtonSettingInput, ButtonSettingEntity> mapExpr);

        partial void MapEntityToView(IMappingExpression<ButtonSettingEntity, ButtonSetting> mapExpr);
    }
}