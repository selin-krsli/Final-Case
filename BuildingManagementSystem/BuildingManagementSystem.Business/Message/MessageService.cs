
using AutoMapper;
using BuildingManagementSystem.Base;
using BuildingManagementSystem.Data;
using BuildingManagementSystem.Schema;
using Hangfire;

namespace BuildingManagementSystem.Business;

public class MessageService : GenericService<Message, MessageRequest, MessageResponse>, IMessageService
{

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public MessageService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper,unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public override ResponseMessage<List<MessageResponse>> GetAll(params string[] includes)
    {
        return base.GetAll(includes);
    }
    public ResponseMessage<IEnumerable<MessageResponse>> WelcomeMessages()
    {
        var jobId = BackgroundJob.Enqueue(() => SendWelcomeEmail("Welcome to our BuildingManagementSystem app"));
        var response = new ResponseMessage<IEnumerable<MessageResponse>>(true)
        {
            Message = "Welcome message job scheduled successfully."
        };
        return response;
    }
    public override ResponseMessage<MessageResponse> GetById(int id, params string[] includes)
    {
        return base.GetById(id, includes);
    }

    public void SendWelcomeEmail(string message)
    {
        throw new NotImplementedException();
    }
}

