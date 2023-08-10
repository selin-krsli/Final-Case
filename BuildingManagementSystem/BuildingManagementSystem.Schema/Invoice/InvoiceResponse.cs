
namespace BuildingManagementSystem.Schema;

public class InvoiceResponse
{
    public int InvoiceId { get; set; }
    public int InvoiceTypeId { get; set; }
    public decimal Amount { get; set; }
    public int Month { get; set; }
    public bool IsPaid { get; set; }
}
