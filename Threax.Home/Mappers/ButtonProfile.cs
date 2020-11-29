using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Tracking;
using Threax.Home.InputModels;
using Threax.Home.Database;
using Threax.Home.ViewModels;
using System.Linq;

namespace Threax.Home.Mappers
{
    public partial class AppMapper
    {
        public ButtonEntity MapButton(ButtonInput src, ButtonEntity dest)
        {
            return mapper.Map(src, dest);
        }

        public Button MapButton(ButtonEntity src, Button dest)
        {
            var mapped = mapper.Map(src, dest);
            mapped.ButtonStates?.Sort((i, j) => i.Order - j.Order);
            SetCurrentIcon(mapped, GetSwitchValue(mapped));
            return mapped;
        }

        public Button MapButton(ButtonEntity src, SwitchEntity liveSwitch, Button dest)
        {
            var mapped = mapper.Map(src, dest);
            mapped.ButtonStates?.Sort((i, j) => i.Order - j.Order);
            SetCurrentIcon(mapped, liveSwitch?.Value ?? GetSwitchValue(mapped));
            return mapped;
        }

        private static string GetSwitchValue(Button mapped)
        {
            return mapped.ButtonStates.FirstOrDefault()?.SwitchSettings.FirstOrDefault()?.Switch?.Value;
        }

        public void SetCurrentIcon(Button dest, String currentValue)
        {
            if (dest.ButtonStates == null)
            {
                return;
            }

            foreach (var state in dest.ButtonStates)
            {
                var switchSettings = state.SwitchSettings.FirstOrDefault();
                if (switchSettings == null)
                {
                    continue;
                }

                if (switchSettings.Value == currentValue)
                {
                    dest.CurrentIcon = state.Icon;
                    return;
                }
            }
        }
    }

    public partial class ButtonProfile : Profile
    {
        public ButtonProfile()
        {
            //Map the input model to the entity
            MapInputToEntity(CreateMap<ButtonInput, ButtonEntity>());

            //Map the entity to the view model.
            MapEntityToView(CreateMap<ButtonEntity, Button>());
        }

        partial void MapInputToEntity(IMappingExpression<ButtonInput, ButtonEntity> mapExpr);

        partial void MapEntityToView(IMappingExpression<ButtonEntity, Button> mapExpr);
    }
}