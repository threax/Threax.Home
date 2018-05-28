using System;
using System.Collections.Generic;
using System.Text;

namespace Threax.Home.Core
{
    public class HomeConfig
    {
        private List<Action<ISwitchSubsystemConfiguration>> switchCallbacks = new List<Action<ISwitchSubsystemConfiguration>>();
        private List<Action<ISensorSubsystemConfiguration>> sensorCallbacks = new List<Action<ISensorSubsystemConfiguration>>();

        public void AddSwitch(Action<ISwitchSubsystemConfiguration> configs)
        {
            switchCallbacks.Add(configs);
        }

        public void AddSwitch(Type baseType)
        {
            AddSwitch(c =>
            {
                c.AddSubsystem((ISwitchRepository)c.Services.GetService(baseType.MakeGenericType(c.TInType, c.TOutType)));
            });
        }

        internal void SetupConfigs(ISwitchSubsystemConfiguration config)
        {
            foreach(var callback in switchCallbacks)
            {
                callback(config);
            }
        }

        public void AddSensorConfig(Action<ISensorSubsystemConfiguration> configs)
        {
            sensorCallbacks.Add(configs);
        }

        public void AddSensorConfig(Type baseType)
        {
            AddSensorConfig(c =>
            {
                c.AddSubsystem((ISensorRepository)c.Services.GetService(baseType.MakeGenericType(c.TSensorType)));
            });
        }

        internal void SetupConfigs(ISensorSubsystemConfiguration config)
        {
            foreach (var callback in sensorCallbacks)
            {
                callback(config);
            }
        }
    }
}
