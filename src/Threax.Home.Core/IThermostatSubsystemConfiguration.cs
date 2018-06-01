using System;
using System.Collections.Generic;
using System.Text;

namespace Threax.Home.Core
{
    public interface IThermostatRepositorySubsystemConfiguration
    {
        void AddSubsystem(IThermostatRepository switchRepo);

        Type TThermostatType { get; }

        IServiceProvider Services { get; }
    }
}
