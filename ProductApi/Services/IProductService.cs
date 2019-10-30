using System.Collections.Generic;
using ProductApi.Models.ApiModels;

namespace ProductApi.Services
{
    public interface IProductService
    {
        /// <summary>
        /// Get a product by it's id.
        /// </summary>
        /// <param name="id">The id of the product.</param>
        /// <param name="culture">The culture of the product.</param>
        /// <returns>The published product with all available product fields.</returns>
        Product GetById(int id, string culture);

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <param name="culture">The culture of the products.</param>
        /// <returns>A list of all published products with a sparse number of product fields for each product.</returns>
        IEnumerable<ProductSparse> GetAll(string culture);

        /// <summary>
        /// Create new product.
        /// </summary>
        /// <param name="model">The product data model to create from.</param>
        /// <returns>The created product.</returns>
        Product Create(ProductCreate model);
    }
}
