
using BuildingManagementSystem.Data;

namespace BuildingManagementSystem.Schema;

public class FlatRequest
{
    public virtual Block Block { get; set; }
    public bool Status { get; set; }
    public string TypeOfFlat { get; set; }
    public int FloorNumber { get; set; }
    public int FlatNumber { get; set; }
    public bool OwnerorTenant { get; set; } //1-Owner 2-Tenant
}
