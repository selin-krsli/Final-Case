using AutoMapper;
using BuildingManagementSystem.Base;
using BuildingManagementSystem.Data;
using BuildingManagementSystem.Schema;

namespace BuildingManagementSystem.Business;

public class CardInformationService : GenericService<CardInformation,CardInformationRequest,CardInformationResponse>, ICardInformationService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public CardInformationService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public CardInformation GetByResidentId(int residentId)
    {
        return _unitOfWork.CardInformationRepository.GetById(residentId);
    }
    public override ResponseMessage<List<CardInformationResponse>> GetAll(params string[] includes)
    {
        return base.GetAll(includes);
    }
    public override ResponseMessage<CardInformationResponse> GetById(int id, params string[] includes)
    {
        return base.GetById(id, includes);
    }


}
