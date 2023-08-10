
namespace BuildingManagementSystem.Schema;

public class CardInformationResponse
{
    public int CardInformationId { get; set; }
    public int ResidentId { get; set; }
    public string ReferenceNumber { get; set; }
    public DateTime ExpiryDate { get; set; }
}
