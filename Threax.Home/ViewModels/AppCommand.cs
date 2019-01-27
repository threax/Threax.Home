using Halcyon.HAL.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Controllers.Api;

namespace Threax.Home.ViewModels
{
    [HalModel]
    [DeclareHalLink(HalSelfActionLinkAttribute.SelfRelName)]
    [DeclareHalLink(AppCommand.Execute)]
    public class AppCommand : IHalLinkProvider
    {
        public const String Execute = nameof(Execute);

        public String Name { get; set; }

        public Guid? ButtonStateId { get; set; }

        public IEnumerable<HalLinkAttribute> CreateHalLinks(ILinkProviderContext context)
        {
            if(ButtonStateId != null)
            {
                yield return new HalActionLinkAttribute(typeof(ButtonStatesController), nameof(ButtonStatesController.Get), HalSelfActionLinkAttribute.SelfRelName);
                yield return new HalActionLinkAttribute(typeof(ButtonStatesController), nameof(ButtonStatesController.Apply), Execute);
            }
        }
    }
}
