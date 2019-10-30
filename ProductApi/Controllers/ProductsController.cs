using System.Web.Http;
using ProductApi.Models.ApiModels;
using ProductApi.Services;

namespace ProductApi.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var currentCulture = GetRequestedCulture();
            var allProducts = _productService.GetAll(currentCulture);

            return Ok(allProducts);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var currentCulture = GetRequestedCulture();
            var product = _productService.GetById(id, currentCulture);

            return Ok(product);
        }

        [HttpPost]
        public IHttpActionResult Create(ProductCreate model)
        {
            var product = _productService.Create(model);

            return CreatedAtRoute("ProductApi", new { Id = product.Id }, product);
        }
    }
}
