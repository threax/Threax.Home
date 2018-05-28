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
        public SensorProfile()
        {
            //Map the input model to the entity
            MapInputToEntity(CreateMap<SensorInput, SensorEntity>());

            //Map the entity to the view model.
            MapEntityToView(CreateMap<SensorEntity, Sensor>());
        }

        partial void MapInputToEntity(IMappingExpression<SensorInput, SensorEntity> mapExpr);

        partial void MapEntityToView(IMappingExpression<SensorEntity, Sensor> mapExpr);
    }
}