namespace Test1_Database_FinalProject.Entities;

internal class OrderEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;
}
