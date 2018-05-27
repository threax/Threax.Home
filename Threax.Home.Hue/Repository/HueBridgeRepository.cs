using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Threax.Home.Hue.Services;
using Threax.Home.Hue.ViewModels;

namespace Threax.Home.Hue.Repository
{
    public class HueBridgeRepository : IHueBridgeRepository
    {
        private IHueClientManager clientManager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clientManager"></param>
        public HueBridgeRepository(IHueClientManager clientManager)
        {
            this.clientManager = clientManager;
        }

        public BridgeCollection List()
        {
            var query = clientManager.GetClientNames().Select(i => new BridgeView()
            {
                Bridge = i
            });
            return new BridgeCollection(query);
        }
    }
}
