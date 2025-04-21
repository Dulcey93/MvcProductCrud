namespace MvcProductCrud.ViewModels
{
    public class ProductDetailsViewModel
    {
        public required int Id { get; set; }
        public string? Name { get; set; }
        public required decimal Price { get; set; }
        public string? Description { get; set; }
        public required string ReleaseDate { get; set; }
        public string? ImagePath { get; set; }
    }
}
