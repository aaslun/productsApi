using System.Linq;
using System.Web.Http;
using Umbraco.Core.Mapping;
using Umbraco.Web;
using UmbracoApiTest.Models;

namespace UmbracoApiTest.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : BaseController
    {
        private readonly UmbracoMapper _umbracoMapper;
        private readonly IUmbracoContextFactory _umbracoContextFactory;

        public ProductsController(IUmbracoContextFactory umbracoContextFactory, UmbracoMapper umbracoMapper)
        {
            _umbracoMapper = umbracoMapper;
            _umbracoContextFactory = umbracoContextFactory;
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns>All products.</returns>
        [HttpGet]
        [Route]
        public IHttpActionResult GetAllProducts()
        {
            using (var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var rootContent = umbracoContextReference.UmbracoContext.Content.GetAtRoot();

                var children = rootContent
                    .FirstOrDefault()
                    ?.Children<Models.ContentTypes.Products>()
                    .FirstOrDefault()
                    ?.Children<Models.ContentTypes.Product>()
                    .Select(x => _umbracoMapper.Map<ProductSparse>(x));

                return Ok(children);
            }
        }

        /// <summary>
        /// Get a product by it's id.
        /// </summary>
        /// <returns>The product.</returns>
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetProductById(int id)
        {
            using (var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var rootContent = umbracoContextReference.UmbracoContext.Content.GetAtRoot();

                var children = rootContent
                    .FirstOrDefault()
                    ?.Children<Models.ContentTypes.Products>()
                    .FirstOrDefault()
                    ?.Children<Models.ContentTypes.Product>()
                    .Select(x => _umbracoMapper.Map<ProductSparse>(x));

                return Ok(children);
            }
        }
    }
}
