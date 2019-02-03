using Halcyon.HAL.Attributes;
using Newtonsoft.Json;
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
    [DeclareHalLink(AppCommand.Rels.Execute)]
    public class AppCommand : IHalLinkProvider
    {
        public static class Rels
        {
            public const String Execute = nameof(Execute);
        }

        public Guid AppCommandId => ButtonStateId ?? throw new InvalidOperationException("No AppCommandId Given");

        public String Name { get; set; }

        [JsonIgnore]
        public Guid? ButtonStateId { get; set; }

        public IEnumerable<HalLinkAttribute> CreateHalLinks(ILinkProviderContext context)
        {
            if(ButtonStateId != null)
            {
                yield return new HalActionLinkAttribute(typeof(ButtonStatesController), nameof(ButtonStatesController.Get), HalSelfActionLinkAttribute.SelfRelName);
                yield return new HalActionLinkAttribute(typeof(ButtonStatesController), nameof(ButtonStatesController.Apply), Rels.Execute);
            }
        }
    }
}
