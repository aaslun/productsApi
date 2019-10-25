using System.Collections.Generic;
using UmbracoApiTest.Models;

namespace UmbracoApiTest.Services
{
    public interface IProductService
    {

        /// <summary>
        /// Get a product by it's id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentCulture"></param>
        /// <returns></returns>
        Product GetById(int id, string currentCulture);

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <param name="currentCulture"></param>
        /// <returns></returns>
        IEnumerable<ProductSparse> GetAll(string currentCulture);
    }
}
