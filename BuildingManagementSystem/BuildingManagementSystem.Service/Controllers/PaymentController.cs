using BuildingManagementSystem.Base;
using BuildingManagementSystem.Business;
using BuildingManagementSystem.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManagementSystem.Service;
[Authorize]
[ApiController]
[Route("mngmt/systm/[controller]")]
public class PaymentController:ControllerBase
{
    private readonly IPaymentService _service;
    public PaymentController(IPaymentService service)
    {
        _service = service;
    }

    [HttpGet]
    public ResponseMessage<List<PaymentResponse>> GetAll()
    {
        var entityList = _service.GetAll();
        return entityList;
    }

    [HttpGet("{id}")]
    public ResponseMessage<PaymentResponse> Get(int id)
    {
        var entity = _service.GetById(id);
        return entity;
    }

    [HttpPost]
    public ResponseMessage Post([FromBody] PaymentRequest request)
    {
        var response = _service.Insert(request);
        return response;
    }
    [HttpPost("process")]
    public ResponseMessage ProcessCreditCardPayment([FromBody] CardPaymentRequest request)
    {
        var response = _service.ProcessCreditCardPayment(request.CardInfo,request.PaymentInfo);
        return response;
    }

    [HttpPut("{id}")]
    public ResponseMessage Put(int id, [FromBody] PaymentRequest request)
    {
        var response = _service.Update(id, request);
        return response;
    }

    [HttpDelete("{id}")]
    public ResponseMessage Delete(int id)
    {
        var response =_service.Delete(id);
        return response;
    }
}
