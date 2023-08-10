
using BuildingManagementSystem.Data;

namespace BuildingManagementSystem.Schema;

public class PaymentResponse
{
    public int PaymentId { get; set; }
    public int ResidentId { get; set; }
    public int InvoiceId { get; set; }
    public decimal PaymentAmount { get; set; }
    public DateTime DueDate { get; set; }
    public string ResidentName { get; set; }
    public virtual ResidentResponse Resident { get; set; }
}
