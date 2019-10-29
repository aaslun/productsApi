using ProductApi.Services;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace ProductApi.Composing
{
    public class ServiceComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register<IProductService, ProductService>();
        }
    }
}
