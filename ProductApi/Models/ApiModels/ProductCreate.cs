namespace ProductApi.Models.ApiModels
{
    public class ProductCreate
    {
        public string Name { get; set; }

        public string Description { get; set; }

        // todo: change to image object
        // public Uri ImageUrl { get; set; }
    }
}
