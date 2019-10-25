using Umbraco.Core.Composing;
using Umbraco.Core.Mapping;
using UmbracoApiTest.Mappings;

namespace UmbracoApiTest.Composing
{
    public class MappingComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.WithCollectionBuilder<MapDefinitionCollectionBuilder>()
                .Add<ProductDefinition>();
        }
    }
}
