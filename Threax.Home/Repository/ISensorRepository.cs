using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Threax.Home.InputModels;
using Threax.Home.ViewModels;
using Threax.Home.Models;
using Threax.AspNetCore.Halcyon.Ext;

namespace Threax.Home.Repository
{
    public partial interface ISensorRepository
    {
        Task<Sensor> Add(SensorInput value);
        Task AddRange(IEnumerable<SensorInput> values);
        Task Delete(Guid id);
        Task<Sensor> Get(Guid sensorId);
        Task<bool> HasSensors();
        Task<SensorCollection> List(SensorQuery query);
        Task<Sensor> Update(Guid sensorId, SensorInput value);
        Task AddMissing(IEnumerable<SensorInput> sensors);
    }
}