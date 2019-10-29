namespace ProductApi.Models.ApiModels
{
    public class ProductSparse
    {
        /// <summary>
        /// The id of the product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The product image.
        /// </summary>
        public string Image { get; set; }
    }
}
