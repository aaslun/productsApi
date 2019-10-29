using System.Collections.Generic;
using System.Linq;
using ProductApi.Models;
using ProductApi.Models.ContentTypes;
using Umbraco.Core.Mapping;
using Umbraco.Web;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly UmbracoMapper _umbracoMapper;
        private readonly IUmbracoContextFactory _umbracoContextFactory;

        public ProductService(IUmbracoContextFactory umbracoContextFactory, UmbracoMapper umbracoMapper)
        {
            _umbracoMapper = umbracoMapper;
            _umbracoContextFactory = umbracoContextFactory;
        }


        public IEnumerable<ProductSparse> GetAll(string currentCulture = null)
        {
            using (var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var rootContent = umbracoContextReference.UmbracoContext.Content.GetAtRoot(currentCulture);

                var children = rootContent
                    .FirstOrDefault()
                    ?.Children<Models.ContentTypes.Products>()
                    .FirstOrDefault()
                    ?.Children<Models.ContentTypes.Product>()
                    .Select(x => _umbracoMapper.Map<ProductSparse>(x));

                return children;
            }
        }

        public Models.Product GetById(int id, string currentCulture = null)
        {
            using (var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var rootContent = umbracoContextReference.UmbracoContext.Content.GetAtRoot(currentCulture);

                var children = rootContent
                    .FirstOrDefault()
                    ?.Children<Models.ContentTypes.Products>()
                    .FirstOrDefault()
                    ?.Children<Models.ContentTypes.Product>()
                    .Select(x => _umbracoMapper.Map<Models.Product>(x));

                var product = children.FirstOrDefault(x => x.Id == id);

                return product;
            }
        }

        public Models.ContentTypes.Product Create(Models.ContentTypes.Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
