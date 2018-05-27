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
        public SwitchProfile()
        {
            //Map the input model to the entity
            MapInputToEntity(CreateMap<SwitchInput, SwitchEntity>());

            //Map the entity to the view model.
            MapEntityToView(CreateMap<SwitchEntity, Switch>());
        }

        partial void MapInputToEntity(IMappingExpression<SwitchInput, SwitchEntity> mapExpr);

        partial void MapEntityToView(IMappingExpression<SwitchEntity, Switch> mapExpr);
    }
}