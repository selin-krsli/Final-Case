
using AutoMapper;
using BuildingManagementSystem.Base;
using BuildingManagementSystem.Data;
using BuildingManagementSystem.Schema;

namespace BuildingManagementSystem.Business;

public interface IMessageService:IGenericService<Message,MessageRequest,MessageResponse>
{
    void SendWelcomeEmail(string message);
    ResponseMessage<IEnumerable<MessageResponse>> WelcomeMessages();
}
