using System.ComponentModel.DataAnnotations;

namespace MvcProductCrud.ViewModels;
public class ProductViewModel
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(255)]
    public string? Description { get; set; }

    [Range(0.01, 10000)]
    public decimal Price { get; set; }

    // Archivo nuevo subido en el formulario
    public IFormFile? Image { get; set; }

    // Ruta completa (para mostrar en vistas)
    public string? ImagePath { get; set; }
}
