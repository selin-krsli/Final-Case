using BuildingManagementSystem.Base;
using BuildingManagementSystem.Business;
using BuildingManagementSystem.Schema;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManagementSystem.Service;

[ApiController]
[Route("mngmt/systm/[controller]")]
public class FlatController:ControllerBase
{
    private readonly IFlatService _service;
    public FlatController(IFlatService service)
    {
        _service = service;
    }
    [HttpGet]
    public ResponseMessage<List<FlatResponse>> GetAll()
    {
        var entityList = _service.GetAll();
        return entityList;
    }

    [HttpGet("{id}")]
    public ResponseMessage<FlatResponse> Get(int id)
    {
        var entity = _service.GetById(id);
        return entity;
    }

    [HttpPost]
    public ResponseMessage Post([FromBody] FlatRequest request)
    {
        var response = _service.Insert(request);
        return response;
    }

    [HttpPut("{id}")]
    public ResponseMessage Put(int id, [FromBody] FlatRequest request)
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
