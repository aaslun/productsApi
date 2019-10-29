using ProductApi.Models;
using Umbraco.Core.Mapping;

namespace ProductApi.Mappings
{
    public class ProductDefinition : IMapDefinition
    {
        public void DefineMaps(UmbracoMapper mapper)
        {
            if (mapper != null)
            {
                mapper.Define<Models.ContentTypes.Product, ProductSparse>(
                    (source, context) => new ProductSparse(),
                    (source, target, context) =>
                    {
                        target.Id = source.Id;
                        target.Name = source.Name;
                        target.Image = source.Image.Url;
                    });

                mapper.Define<Models.ContentTypes.Product, Product>(
                    (source, context) => new Product(),
                    (source, target, context) =>
                    {
                        target.Id = source.Id;
                        target.Name = source.Name;
                        target.Description = source.Description;
                        target.Image = source.Image.Url;
                    });
            }
        }
    }
}
