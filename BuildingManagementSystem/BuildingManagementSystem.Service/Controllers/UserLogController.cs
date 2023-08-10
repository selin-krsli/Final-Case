using BuildingManagementSystem.Base;
using BuildingManagementSystem.Business;
using BuildingManagementSystem.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManagementSystem.Service;
[Authorize]
[ApiController]
[Route("mngmt/systm/[controller]")]
public class UserLogController : ControllerBase
{
    private readonly IUserLogService _service;
    public UserLogController(IUserLogService service)
    {
        _service = service;
    }

    [HttpGet]
    public ResponseMessage<List<UserLogResponse>> GetAll()
    {
        var entityList = _service.GetAll();
        return entityList;
    }

    [HttpGet("{id}")]
    public ResponseMessage<UserLogResponse> Get(int id)
    {
        var entity = _service.GetById(id);
        return entity;
    }

    [HttpPost]
    public ResponseMessage Post([FromBody] UserLogRequest request)
    {
        var response = _service.Insert(request);
        return response;
    }

    [HttpPut("{id}")]
    public ResponseMessage Put(int id, [FromBody] UserLogRequest request)
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
