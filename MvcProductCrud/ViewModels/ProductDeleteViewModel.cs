namespace MvcProductCrud.ViewModels
{
    public class ProductDeleteViewModel
    {
        public required int Id { get; set; }

        public string? Name { get; set; }

        public required decimal Price { get; set; }

        public string? ImagePath { get; set; }
    }
}
