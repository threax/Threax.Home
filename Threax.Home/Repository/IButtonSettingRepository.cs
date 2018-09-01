using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Threax.Home.InputModels;
using Threax.Home.ViewModels;
using Threax.Home.Models;
using Threax.AspNetCore.Halcyon.Ext;

namespace Threax.Home.Repository
{
    public partial interface IButtonSettingRepository
    {
        Task<ButtonSetting> Add(ButtonSettingInput value);
        Task AddRange(IEnumerable<ButtonSettingInput> values);
        Task Delete(Guid id);
        Task<ButtonSetting> Get(Guid buttonSettingId);
        Task<bool> HasButtonSettings();
        Task<ButtonSettingCollection> List(ButtonSettingQuery query);
        Task<ButtonSetting> Update(Guid buttonSettingId, ButtonSettingInput value);
    }
}