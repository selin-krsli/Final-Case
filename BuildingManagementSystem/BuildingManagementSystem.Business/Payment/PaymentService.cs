
using AutoMapper;
using BuildingManagementSystem.Base;
using BuildingManagementSystem.Data;
using BuildingManagementSystem.Schema;

namespace BuildingManagementSystem.Business;

public class PaymentService:GenericService<Payment,PaymentRequest,PaymentResponse>, IPaymentService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICardInformationService _cardInformationService;
    public PaymentService(IMapper mapper, IUnitOfWork unitOfWork, ICardInformationService cardInformationService):base(mapper, unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _cardInformationService = cardInformationService;
    }
    public override ResponseMessage<List<PaymentResponse>> GetAll(params string[] includes)
    {
        return base.GetAll(includes);
    }
    public override ResponseMessage<PaymentResponse> GetById(int id, params string[] includes)
    {
        return base.GetById(id, includes);
    }
    public ResponseMessage ProcessCreditCardPayment(CardInformationRequest cardInfoRequest, PaymentRequest paymentRequest)
    {
        var cardInfo = _cardInformationService.GetByResidentId(cardInfoRequest.ResidentId);
        if(cardInfo == null || cardInfo.ReferenceNumber != cardInfoRequest.ReferenceNumber || cardInfo.CVV != cardInfoRequest.CVV)
        {
            return new ResponseMessage("Invalid Credit Card Information!!");
        }
        if(cardInfo.ExpiryDate < DateTime.Now) 
        {
            return new ResponseMessage("Credit Card has expired!!");
        }
        if(string.IsNullOrWhiteSpace(cardInfo.CVV) || cardInfo.CVV.Length !=3)
        {
            return new ResponseMessage("Invalid CVV!!");
        }
        decimal paymentLimit = 3000;
        if(paymentRequest.PaymentAmount>paymentLimit)
        {
            return new ResponseMessage("Payment Amount exceeds the limit!!");
        }
        var payment = new Payment
        {
            ResidentId = cardInfoRequest.ResidentId,
            PaymentAmount = paymentRequest.PaymentAmount,
            DueDate = paymentRequest.DueDate,
        };
        _unitOfWork.PaymentRepository.Insert(payment);
        _unitOfWork.Complete();
        return new ResponseMessage("Payment Successful!!");
    }
  }

