using System.Web.Http;
using UmbracoApiTest.Services;

namespace UmbracoApiTest.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route]
        public IHttpActionResult GetAll()
        {
            var currentCulture = GetRequestedCulture();
            var allProducts = _productService.GetAll(currentCulture);

            return Ok(allProducts);
        }


        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var currentCulture = GetRequestedCulture();
            var product = _productService.GetById(id, currentCulture);

            return Ok(product);
        }
    }
}
