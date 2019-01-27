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

            CreateMap<SwitchEntity, SwitchEntity>()
                .ForMember(d => d.SwitchId, opt => opt.Ignore())
                .ForMember(d => d.Subsystem, opt => opt.Ignore())
                .ForMember(d => d.Bridge, opt => opt.Ignore())
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Name, opt => opt.Ignore());

            CreateMap<SetSwitchInput, SwitchEntity>()
                .ForMember(d => d.SwitchId, opt => opt.Ignore())
                .ForMember(d => d.Subsystem, opt => opt.Ignore())
                .ForMember(d => d.Bridge, opt => opt.Ignore())
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Name, opt => opt.Ignore())
                .ForMember(d => d.Created, opt => opt.MapFrom<ICreatedResolver>())
                .ForMember(d => d.Modified, opt => opt.MapFrom<IModifiedResolver>());
        }

        partial void MapInputToEntity(IMappingExpression<SwitchInput, SwitchEntity> mapExpr);

        partial void MapEntityToView(IMappingExpression<SwitchEntity, Switch> mapExpr);
    }
}