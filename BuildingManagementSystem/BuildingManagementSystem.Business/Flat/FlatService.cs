
using AutoMapper;
using BuildingManagementSystem.Base;
using BuildingManagementSystem.Data;
using BuildingManagementSystem.Schema;

namespace BuildingManagementSystem.Business;

public class FlatService : GenericService<Flat, FlatRequest, FlatResponse>, IFlatService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public FlatService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public override ResponseMessage<List<FlatResponse>> GetAll(params string[] includes)
    {
        return base.GetAll(includes);
    }
    public override ResponseMessage<FlatResponse> GetById(int id, params string[] includes)
    {
        return base.GetById(id, includes);
    }
}
