using Umbraco.Core;
using Umbraco.Core.Composing;
using UmbracoApiTest.Services;

namespace UmbracoApiTest.Composing
{
    public class ServiceComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register<IProductService, ProductService>();
        }
    }
}
