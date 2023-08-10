
using AutoMapper;
using BuildingManagementSystem.Data;
using BuildingManagementSystem.Schema;

namespace BuildingManagementSystem.Business;

public class UserService : GenericService<User, UserRequest, UserResponse>, IUserService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public UserService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
}
