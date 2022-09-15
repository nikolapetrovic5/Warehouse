namespace Warehouse.Entity;

public sealed class Account
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Pin { get; set; } = string.Empty;
    public DateTime IngestionDate { get; set; } = DateTime.Now;
    public string Email { get; set; } = string.Empty;
}
