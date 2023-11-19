using System.ComponentModel.DataAnnotations.Schema;

namespace Test1_Database_FinalProject.Entities;

internal class ProductEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Colour { get; set; } = null!;
    public string Description { get; set; } = null!;
    [Column(TypeName = "money")]
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
    public int SupplierId { get; set; }
    public SupplierEntity Supplier { get; set; } = null!;   

    
}
