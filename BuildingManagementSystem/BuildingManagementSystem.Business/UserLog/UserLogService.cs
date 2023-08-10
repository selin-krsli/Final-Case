
using AutoMapper;
using BuildingManagementSystem.Data;
using BuildingManagementSystem.Schema;

namespace BuildingManagementSystem.Business;

public class UserLogService : GenericService<UserLog, UserLogRequest, UserLogResponse>, IUserLogService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public UserLogService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
}
