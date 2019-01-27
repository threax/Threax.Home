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
        public ButtonStateEntity MapButtonState(ButtonStateInput src, ButtonStateEntity dest)
        {
            return mapper.Map(src, dest);
        }

        public ButtonState MapButtonState(ButtonStateEntity src, ButtonState dest)
        {
            return mapper.Map(src, dest);
        }
    }

    public partial class ButtonStateProfile : Profile
    {
        public ButtonStateProfile()
        {
            //Map the input model to the entity
            MapInputToEntity(CreateMap<ButtonStateInput, ButtonStateEntity>());

            //Map the entity to the view model.
            MapEntityToView(CreateMap<ButtonStateEntity, ButtonState>());
        }

        void MapInputToEntity(IMappingExpression<ButtonStateInput, ButtonStateEntity> mapExpr)
        {
            mapExpr.ForMember(d => d.ButtonStateId, opt => opt.Ignore())
                .ForMember(d => d.Created, opt => opt.MapFrom<ICreatedResolver>())
                .ForMember(d => d.Modified, opt => opt.MapFrom<IModifiedResolver>());
        }

        void MapEntityToView(IMappingExpression<ButtonStateEntity, ButtonState> mapExpr)
        {
            
        }
    }
}