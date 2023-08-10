using AutoMapper;
using BuildingManagementSystem.Base;
using BuildingManagementSystem.Business;
using BuildingManagementSystem.Data;
using BuildingManagementSystem.Schema;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManagementSystem.Service;

[ApiController]
[Route("mngmt/systm/[controller]")]
public class InvoiceController:ControllerBase
{
    private readonly IInvoiceService _service;
    public InvoiceController(IInvoiceService service)
    {
        _service = service;
    }
    [HttpGet]
    public ResponseMessage<List<InvoiceResponse>> GetAll()
    {
        var entityList = _service.GetAll();
        return entityList;
    }

    [HttpGet("{id}")]
    public ResponseMessage<InvoiceResponse> Get(int id)
    {
        var entity = _service.GetById(id);
        return entity;
    }

    [HttpPost]
    public ResponseMessage Post([FromBody] InvoiceRequest request)
    {
        var response = _service.Insert(request);
        return response;
    }

    [HttpPut("{id}")]
    public ResponseMessage Put(int id, [FromBody] InvoiceRequest request)
    {
        var response = _service.Update(id, request);
        return response;
    }

    [HttpDelete("{id}")]
    public ResponseMessage Delete(int id)
    {
        var response = _service.Delete(id);
        return response;
    }
}
