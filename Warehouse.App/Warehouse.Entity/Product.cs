namespace Warehouse.Entity;

public sealed class Product
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public decimal Price { get; set; } = decimal.Zero;
    public string Note { get; set; } = string.Empty;
    public int Quantity { get; set; } = 0;
    public string Currency { get; set; } = string.Empty;
    public DateTime ArrivalDate { get; set; } = DateTime.Now;
    public DateTime IngestionDate { get; set; } = DateTime.Now;
}
