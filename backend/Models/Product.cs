// example of a database model

// Models act as data structures
namespace backend.Models;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public decimal Price { get; set; }
}