
using BuildingManagementSystem.Data;
using BuildingManagementSystem.Schema;

namespace BuildingManagementSystem.Business;

public interface ICardInformationService:IGenericService<CardInformation, CardInformationRequest, CardInformationResponse>
{
    CardInformation GetByResidentId(int residentId);    
}
