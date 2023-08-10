using BuildingManagementSystem.Base;
using BuildingManagementSystem.Business;
using BuildingManagementSystem.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManagementSystem.Service;

[ApiController]
[Route("mngmt/systm/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    public UserController(IUserService service)
    {
        _service = service;
    }
    [Authorize]
    [HttpGet]
    public ResponseMessage<List<UserResponse>> GetAll()
    {
        var entityList = _service.GetAll();
        return entityList;
    }
    [Authorize]
    [HttpGet("{id}")]
    public ResponseMessage<UserResponse> Get(int id)
    {
        var entity = _service.GetById(id);
        return entity;
    }

    [HttpPost]
    public ResponseMessage Post([FromBody] UserRequest request)
    {
        var response = _service.Insert(request);
        return response;
    }
    [Authorize]
    [HttpPut("{id}")]
    public ResponseMessage Put(int id, [FromBody] UserRequest request)
    {
        var response = _service.Update(id, request);
        return response;
    }
    [Authorize]
    [HttpDelete("{id}")]
    public ResponseMessage Delete(int id)
    {
        var response = _service.Delete(id);
        return response;
    }
}
