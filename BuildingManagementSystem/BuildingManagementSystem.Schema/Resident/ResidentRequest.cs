

using BuildingManagementSystem.Data;

namespace BuildingManagementSystem.Schema;

public class ResidentRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TCNo { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public string VehiclePlate { get; set; }


    // Navigation Properties
    public virtual List<FlatResponse> Flats { get; set; }
}
