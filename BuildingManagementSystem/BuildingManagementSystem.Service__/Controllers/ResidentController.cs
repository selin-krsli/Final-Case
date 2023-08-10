using BuildingManagementSystem.Base;
using BuildingManagementSystem.Business;
using BuildingManagementSystem.Schema;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManagementSystem.Service;

[ApiController]
[Route("mngmt/systm/[controller]")]
public class ResidentController:ControllerBase
{
    private readonly IResidentService _service;
    public ResidentController(IResidentService service)
    {
        _service = service;
    }

    [HttpGet]
    public ResponseMessage<List<ResidentResponse>> GetAll()
    {                                    //Include   //ThenInclude
        var entityList = _service.GetAll("Flats", "Flats.Invoices");
        return entityList;
    }

    [HttpGet("{id}")]
    public ResponseMessage<ResidentResponse> Get(int id)
    {
        //var entity = _service.GetById(id, "Flats", "Flats.Invoices");normalde 
        var entity = _service.GetById(id,"Flats.Invoices");
        return entity;
    }

    [HttpPost]
    public ResponseMessage Post([FromBody] ResidentRequest request)
    {
        var response = _service.Insert(request);
        return response;
    }

    [HttpPut("{id}")]
    public ResponseMessage Put(int id, [FromBody] ResidentRequest request)
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
