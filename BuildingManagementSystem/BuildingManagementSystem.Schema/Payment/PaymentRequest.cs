
using BuildingManagementSystem.Data;

namespace BuildingManagementSystem.Schema;

public class PaymentRequest
{
    public decimal PaymentAmount { get; set; }
    public DateTime DueDate { get; set; }
}
