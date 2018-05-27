using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Threax.Home.Database;

namespace Threax.Home.Repository
{
    public interface ISwitchIdRepository
    {
        SwitchEntity GetLoaded(SwitchIdLookup lookup);
        Task<SwitchEntity> Load(Guid id);
        Task Load(IEnumerable<SwitchIdLookup> lookups);
        Task Load(SwitchIdLookup lookup);
    }
}