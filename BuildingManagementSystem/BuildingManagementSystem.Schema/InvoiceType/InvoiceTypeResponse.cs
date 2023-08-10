
namespace BuildingManagementSystem.Schema;

public class InvoiceTypeResponse
{
    public int InvoiceTypeId { get; set; }
    public string InvoiceTypeName { get; set; }
    public virtual List<InvoiceResponse> Invoices { get; set; }
}
