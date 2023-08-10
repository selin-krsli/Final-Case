
using AutoMapper;
using BuildingManagementSystem.Base;
using BuildingManagementSystem.Data;
using BuildingManagementSystem.Schema;

namespace BuildingManagementSystem.Business;

public class InvoiceService : GenericService<Invoice, InvoiceRequest, InvoiceResponse>, IInvoiceService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public InvoiceService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public override ResponseMessage<List<InvoiceResponse>> GetAll(params string[] includes)
    {
        return base.GetAll(includes);
    }
    public override ResponseMessage<InvoiceResponse> GetById(int id, params string[] includes)
    {
        return base.GetById(id, includes);
    }
}
