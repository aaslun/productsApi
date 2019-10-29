using System.Collections.Generic;
using System.Linq;
using ProductApi.Exceptions;
using ProductApi.Models.ApiModels;
using ProductApi.Models.ContentTypes;
using Umbraco.Core.Mapping;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly UmbracoMapper _umbracoMapper;
        private readonly IUmbracoContextFactory _umbracoContextFactory;
        private readonly IContentService _contentService;

        public ProductService(IUmbracoContextFactory umbracoContextFactory, UmbracoMapper umbracoMapper, IContentService contentService)
        {
            _umbracoMapper = umbracoMapper;
            _umbracoContextFactory = umbracoContextFactory;
            _contentService = contentService;
        }

        public IEnumerable<ProductSparse> GetAll(string culture = null)
        {
            using (var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var rootContent = umbracoContextReference.UmbracoContext.Content.GetAtRoot(culture);

                var children = rootContent
                    .FirstOrDefault()
                    ?.Children<ProductsContentType>()
                    .FirstOrDefault()
                    ?.Children<ProductContentType>()
                    .Select(x => _umbracoMapper.Map<ProductSparse>(x));

                return children;
            }
        }

        public Product GetById(int id, string culture = null)
        {
            using (var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var rootContent = umbracoContextReference.UmbracoContext.Content.GetAtRoot(culture);

                var productContent = rootContent
                    .FirstOrDefault()
                    ?.Children<ProductsContentType>()
                    .FirstOrDefault()
                    ?.Children<ProductContentType>()
                    .FirstOrDefault(x => x.Id == id);

                if (productContent == null)
                {
                    throw new EntityNotFoundException(typeof(Product));
                }

                var product = _umbracoMapper.Map<Product>(productContent);

                return product;
            }
        }

        public Product Create(ProductPostData model)
        {
            if (model == null)
            {
                throw new BadRequestException("Empty model");
            }

            var productRoot = GetProductRootPage();
            if (productRoot == null)
            {
                throw new EntityNotFoundException(typeof(ProductContentType));
            }

            var product = _contentService.Create(model.Name, productRoot.Id, ProductContentType.ModelTypeAlias);

            product.SetValue(nameof(ProductContentType.Description), model.Description);
            // product.SetValue(nameof(ProductContentType.Image), model.ImageUrl);

            var result = _contentService.SaveAndPublish(product);

            if (!result.Success)
            {
                throw new BadRequestException("Unable to create product");
            }

            return GetById(product.Id);
        }

        private ProductsContentType GetProductRootPage(string culture = null)
        {
            using (var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var rootContent = umbracoContextReference.UmbracoContext.Content.GetAtRoot(culture);

                return rootContent
                    .FirstOrDefault()
                    ?.Children<ProductsContentType>()
                    .FirstOrDefault();
            }
        }
    }
}
