using System;
using Threax.Home.Database;
using Threax.Home.InputModels;
using Threax.Home.ViewModels;

namespace Threax.Home.Mappers
{
    public partial class AppMapper
    {
        public SensorEntity MapSensor(SensorInput src, SensorEntity dest)
        {
            //dest.SensorId ignored
            dest.Name = src.Name;
            dest.Subsystem = src.Subsystem;
            dest.Bridge = src.Bridge;
            dest.Id = src.Id;
            dest.TempValue = src.TempValue;
            dest.TempUnits = src.TempUnits;
            dest.LightValue = src.LightValue;
            dest.LightUnits = src.LightUnits;
            dest.HumidityValue = src.HumidityValue;
            dest.HumidityUnits = src.HumidityUnits;
            dest.UvValue = src.UvValue;
            dest.UvUnits = src.UvUnits;
            dest.Created = GetCreated(dest.Created);
            dest.Modified = DateTime.UtcNow;

            return dest;
        }
        public Sensor MapSensor(SensorEntity src, Sensor dest)
        {
            dest.SensorId = src.SensorId;
            dest.Name = src.Name;
            dest.Subsystem = src.Subsystem;
            dest.Bridge = src.Bridge;
            dest.Id = src.Id;
            dest.TempValue = src.TempValue;
            dest.TempUnits = src.TempUnits;
            dest.LightValue = src.LightValue;
            dest.LightUnits = src.LightUnits;
            dest.HumidityValue = src.HumidityValue;
            dest.HumidityUnits = src.HumidityUnits;
            dest.UvValue = src.UvValue;
            dest.UvUnits = src.UvUnits;
            dest.Created = src.Created;
            dest.Modified = src.Modified;

            return dest;
        }
    }
}