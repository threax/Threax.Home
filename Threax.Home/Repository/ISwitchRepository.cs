using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Threax.Home.InputModels;
using Threax.Home.ViewModels;
using Threax.Home.Models;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;
using Threax.Home.Database;

namespace Threax.Home.Repository
{
    public partial interface ISwitchRepository
    {
        //Task<Switch> Add(SwitchInput value);
        //Task AddRange(IEnumerable<SwitchInput> values);
        Task Delete(Guid id);
        Task<Switch> Get(Guid switchId);
        Task<bool> HasSwitches();
        Task<SwitchCollection> List(SwitchQuery query);
        Task<Switch> Update(Guid switchId, SwitchInput value);
        Task<Switch> Set(Guid switchId, SetSwitchInput @switch);
        Task AddNewSwitches();
        Task<IEnumerable<ILabelValuePair>> GetSwitchLabels();
    }
}