
using BuildingManagementSystem.Base;
using BuildingManagementSystem.Data;
using BuildingManagementSystem.Schema;

namespace BuildingManagementSystem.Business;

public interface IPaymentService:IGenericService<Payment,PaymentRequest,PaymentResponse>
{
    ResponseMessage ProcessCreditCardPayment(CardInformationRequest cardInfoRequest, PaymentRequest paymentRequest);
}
