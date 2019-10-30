using System.Collections.Generic;
using System.Linq;
using ProductApi.Exceptions;
using ProductApi.Models.ApiModels;
using ProductApi.Models.ContentTypes;
using Umbraco.Core.Logging;
using Umbraco.Core.Mapping;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly UmbracoMapper _umbracoMapper;
        private readonly IUmbracoContextFactory _umbracoContextFactory;
        private readonly ILogger _logger;
        private readonly IContentService _contentService;

        public ProductService(
            IUmbracoContextFactory umbracoContextFactory,
            UmbracoMapper umbracoMapper,
            ILogger logger,
            IContentService contentService)
        {
            _umbracoMapper = umbracoMapper ?? throw new System.ArgumentNullException(nameof(umbracoMapper));
            _umbracoContextFactory = umbracoContextFactory ?? throw new System.ArgumentNullException(nameof(umbracoContextFactory));
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            _contentService = contentService ?? throw new System.ArgumentNullException(nameof(contentService));

        }

        public IEnumerable<ProductSparse> GetAll(string culture = null)
        {
            var productRoot = GetProductRootPage();
            if (productRoot == null)
            {
                throw new EntityNotFoundException(typeof(ProductContentType));
            }

            var children = productRoot
                .Children<ProductContentType>()
                .Select(x => _umbracoMapper.Map<ProductSparse>(x));

            return children;
        }

        public Product GetById(int id, string culture = null)
        {
            var productRoot = GetProductRootPage();
            if (productRoot == null)
            {
                throw new EntityNotFoundException(typeof(ProductContentType));
            }

            var productContent = productRoot
                .Children<ProductContentType>()
                .FirstOrDefault(x => x.Id == id);

            if (productContent == null)
            {
                throw new EntityNotFoundException(typeof(Product));
            }

            var product = _umbracoMapper.Map<Product>(productContent);

            return product;
        }

        public Product Create(ProductCreate model)
        {
            if (model == null)
            {
                throw new BadRequestException($"{nameof(ProductCreate)} model cannot be empty");
            }

            var productRoot = GetProductRootPage();
            if (productRoot == null)
            {
                throw new EntityNotFoundException(typeof(ProductContentType));
            }

            var product = _contentService.Create(model.Name, productRoot.Id, ProductContentType.ModelTypeAlias);

            product.SetValue(nameof(ProductContentType.Description), model.Description);

            var result = _contentService.SaveAndPublish(product);

            if (!result.Success)
            {
                throw new BadRequestException("Failed creating new product");
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
