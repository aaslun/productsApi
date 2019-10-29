using ProductApi.Mappings;
using Umbraco.Core.Composing;
using Umbraco.Core.Mapping;

namespace ProductApi.Composing
{
    public class MappingComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            if (composition != null)
            {
                composition.WithCollectionBuilder<MapDefinitionCollectionBuilder>()
                    .Add<ProductDefinition>();
            }
        }
    }
}
