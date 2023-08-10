
using BuildingManagementSystem.Data;

namespace BuildingManagementSystem.Schema;

public class ResidentResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TCNo { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string VehiclePlate { get; set; }
    public string ResidentName { get; set; }

    // Navigation Properties
    public virtual List<FlatResponse> Flats { get; set; }
   // public virtual List<InvoiceResponse> Invoices { get; set; } 
    //public virtual List<PaymentResponse> Payment { get; set; }
}
