using System;
using System.Collections.Generic;
using System.Text;

namespace Threax.Home.Core
{
    public interface ISensorSubsystemConfiguration
    {
        void AddSubsystem(ISensorRepository switchRepo);

        Type TSensorType { get; }

        IServiceProvider Services { get; }
    }
}
