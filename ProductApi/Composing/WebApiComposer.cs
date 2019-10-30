using Umbraco.Core;
using Umbraco.Core.Composing;

namespace ProductApi.Composing
{
    public class WebApiComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            // Disabled. See comment in WebApiComponent.cs for reason.
            composition.Components().Append<WebApiComponent>();
        }
    }
}
