
using BuildingManagementSystem.Data;

namespace BuildingManagementSystem.Schema;

public class FlatResponse
{
    public int BlockId { get; set; }
    public bool Status { get; set; }
    public string TypeOfFlat { get; set; }
    public int FloorNumber { get; set; }
    public int FlatNumber { get; set; }
    public bool OwnerorTenant { get; set; } //1-Owner 2-Tenant
    public int ResidentId { get; set; }

    //public virtual List<InvoiceResponse> Invoices { get; set; }
}

