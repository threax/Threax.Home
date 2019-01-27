using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Threax.Home.Core;
using Threax.Home.Database;
using Threax.Home.InputModels;
using Threax.Home.ViewModels;

namespace Threax.Home.Repository
{
    public interface IButtonStateRepository
    {
        Task<Button> Add(ButtonInput button);
        Task AddRange(IEnumerable<ButtonInput> buttons);
        Task<Button> Apply(Guid buttonStateId, ISwitchSubsystemManager<SwitchEntity, SwitchEntity> switchRepo);
        Task<ButtonState> Get(Guid buttonId);
        Task<ButtonStateCollection> List(ButtonStateQuery query);
    }
}