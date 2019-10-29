namespace ProductApi.Models
{
    public class Product
    {
        /// <summary>
        /// The id of the product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The nema of the product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The image for the product.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// The description of the product.
        /// </summary>
        public string Description { get; set; }
    }
}
