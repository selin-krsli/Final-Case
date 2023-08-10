
namespace BuildingManagementSystem.Schema;

public class CardPaymentRequest
{
    public CardInformationRequest CardInfo { get; set; }
    public PaymentRequest PaymentInfo { get; set; }
}
