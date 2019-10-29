using System.Web.Http;
using ProductApi.Exceptions;
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

            if (product == null)
            {
                throw new EntityNotFoundException();
            }

            return Ok(product);
        }

        //[HttpPost]
        //[Route("create")]
        //public HttpResponseMessage Create(Product product)
        //{
        //    var response = _productService.Create(product);

        //    return Ok(response);
        //}
    }
}
