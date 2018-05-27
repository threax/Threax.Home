using System;
using System.Collections.Generic;
using System.Text;

namespace Threax.Home.Core
{
    public class HomeConfig
    {
        private List<Action<ISwitchSubsystemConfiguration>> addSubsystemCallbacks = new List<Action<ISwitchSubsystemConfiguration>>();

        public void AddConfig(Action<ISwitchSubsystemConfiguration> configs)
        {
            addSubsystemCallbacks.Add(configs);
        }

        public void AddConfig(Type baseType)
        {
            addSubsystemCallbacks.Add(c =>
            {
                c.AddSubsystem((ISwitchRepository)c.Services.GetService(baseType.MakeGenericType(c.TInType, c.TOutType)));
            });
        }

        internal void SetupConfigs(ISwitchSubsystemConfiguration config)
        {
            foreach(var callback in addSubsystemCallbacks)
            {
                callback(config);
            }
        }
    }
}
