using BuildingManagementSystem.Base;
using BuildingManagementSystem.Business;
using BuildingManagementSystem.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManagementSystem.Service;
[Authorize]
[ApiController]
[Route("mngmt/systm/[controller]")]
public class MessageController:ControllerBase
{
    private readonly IMessageService _service;
    public MessageController(IMessageService service)
    {
        _service = service;
    }
    [HttpGet]
    public ResponseMessage<List<MessageResponse>> GetAll()
    {
        var entityList = _service.GetAll();
        return entityList;
    }

    [HttpGet("{id}")]
    public ResponseMessage<MessageResponse> Get(int id)
    {
        var entity = _service.GetById(id);
        return entity;
    }

    [HttpPost]
    public ResponseMessage Post([FromBody] MessageRequest request)
    {
        var response = _service.Insert(request);
        return response;
    }

    [HttpPut("{id}")]
    public ResponseMessage Put(int id, [FromBody] MessageRequest request)
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
    // GET: api/Messages/Unread
    //[HttpGet("Unread")]
    //public IActionResult GetUnreadMessages()
    //{
    //    var entity = _unitOfWork.MessageRepository.GetUnReadMessages();
    //    var mapped = _mapper.Map<Message, MessageResponse>(entity);
    //    return new ResponseMessage();
    //}
}
