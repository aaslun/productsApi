using System.Web.Http;
using ProductApi.Models.ApiModels;
using ProductApi.Services;

namespace ProductApi.Controllers
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

        [HttpPost]
        [Route]
        public IHttpActionResult Create(ProductPostData model)
        {
            var product = _productService.Create(model);

            return CreatedAtRoute(string.Empty, new { Id = product.Id }, product);
        }
    }
}
