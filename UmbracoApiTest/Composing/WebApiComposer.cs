using Umbraco.Core;
using Umbraco.Core.Composing;

namespace UmbracoApiTest.Composing
{
    public class WebApiComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<WebApiComponent>();
        }
    }
}
