// example of a database model

// Models act as data structures
using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class Product
{
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Name { get; set; } = "";

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }
}