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
        public AppCommand MapButtonState(ButtonStateEntity src, AppCommand dest)
        {
            return mapper.Map(src, dest);
        }
    }

    public partial class AppCommandProfile : Profile
    {
        public AppCommandProfile()
        {
            //Map the entity to the view model.
            CreateMap<ButtonStateEntity, AppCommand>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Button.Label + " - " + s.Label))
                .ForMember(d => d.ButtonStateId, o => o.MapFrom(s => s.ButtonStateId))
                .ForAllOtherMembers(o => o.Ignore());
        }
    }
}