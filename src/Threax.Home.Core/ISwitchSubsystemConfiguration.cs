using System;
using System.Collections.Generic;
using System.Text;

namespace Threax.Home.Core
{
    public interface ISwitchSubsystemConfiguration
    {
        void AddSubsystem(ISwitchRepository switchRepo);

        Type TInType { get; }

        Type TOutType { get; }

        IServiceProvider Services { get; }
    }
}
