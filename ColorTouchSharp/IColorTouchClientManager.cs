using System.Collections.Generic;

namespace ColorTouchSharp
{
    public interface IColorTouchClientManager
    {
        void AddClient(IColorTouchClient client);
        IColorTouchClient GetClient(string name);
        IEnumerable<IColorTouchClient> Clients { get; }
    }
}