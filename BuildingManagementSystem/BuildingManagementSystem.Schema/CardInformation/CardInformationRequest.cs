
namespace BuildingManagementSystem.Schema;

public class CardInformationRequest
{
    public int ResidentId { get; set; }
    public string ReferenceNumber { get; set; }
    public string CVV { get; set; }
    //public DateTime ExpiryDate { get; set; }
}
