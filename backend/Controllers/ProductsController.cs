// This is an example of a Controller for PRODUCTS

// Controllers act as API endpoints

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(_context.Products.ToList());
    }

    [HttpPost]
    public IActionResult CreateProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
    }
}