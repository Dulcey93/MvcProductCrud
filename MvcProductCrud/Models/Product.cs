using System.ComponentModel.DataAnnotations;

namespace MvcProductCrud.Models;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100)]
    public required string Name { get; set; }

    [DataType(DataType.Currency)]
    [Range(0.01, 10000)]
    public decimal Price { get; set; }

    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
}
