
namespace BuildingManagementSystem.Schema;

public class InvoiceRequest
{
    public int InvoiceTypeId { get; set; }
    public int ResidentId { get; set; }
    public decimal Amount { get; set; }
    public int Month { get; set; }
    public bool IsPaid { get; set; }
}
