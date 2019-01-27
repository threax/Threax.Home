using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Threax.Home.InputModels;
using Threax.Home.ViewModels;
using Threax.Home.Models;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Core;
using Threax.Home.Database;

namespace Threax.Home.Repository
{
    public partial interface IButtonRepository
    {
        Task<Button> Add(ButtonInput value);
        Task AddRange(IEnumerable<ButtonInput> values);
        Task Delete(Guid id);
        Task<Button> Get(Guid buttonId);
        Task<bool> HasButtons();
        Task<ButtonCollection> List(ButtonQuery query);
        Task<Button> Update(Guid buttonId, ButtonInput value);
    }
}