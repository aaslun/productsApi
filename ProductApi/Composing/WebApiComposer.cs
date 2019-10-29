using Umbraco.Core;
using Umbraco.Core.Composing;

namespace ProductApi.Composing
{
    public class WebApiComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<WebApiComponent>();
        }
    }
}
