
using BuildingManagementSystem.Base;

namespace BuildingManagementSystem.Business;

public interface IGenericService<TEntity, TRequest, TResponse>
{
    ResponseMessage<List<TResponse>> GetAll(params string[] includes);
    ResponseMessage<TResponse> GetById(int id, params string[] includes);
    ResponseMessage Insert(TRequest request);
    ResponseMessage Update(int id, TRequest request);
    ResponseMessage Delete(int id);
}
