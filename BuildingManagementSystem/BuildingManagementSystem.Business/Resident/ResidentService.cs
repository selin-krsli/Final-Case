
using AutoMapper;
using BuildingManagementSystem.Base;
using BuildingManagementSystem.Data;
using BuildingManagementSystem.Schema;

namespace BuildingManagementSystem.Business;

public class ResidentService:GenericService<Resident, ResidentRequest, ResidentResponse>, IResidentService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public ResidentService(IMapper mapper, IUnitOfWork unitOfWork):base(mapper, unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public override ResponseMessage<List<ResidentResponse>> GetAll(params string[] includes)
    {
        return base.GetAll(includes);   
    }
    public override ResponseMessage<ResidentResponse> GetById(int id, params string[] includes)
    {
        return base.GetById(id, includes);
    }
}
