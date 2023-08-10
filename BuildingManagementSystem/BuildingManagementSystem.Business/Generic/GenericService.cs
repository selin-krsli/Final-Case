
using AutoMapper;
using BuildingManagementSystem.Base;
using BuildingManagementSystem.Data;
using BuildingManagementSystem.Data.Repository;
using Serilog;

namespace BuildingManagementSystem.Business;

public class GenericService<TEntity, TRequest, TResponse> : IGenericService<TEntity, TRequest, TResponse> where TEntity : class
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public GenericService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public virtual ResponseMessage Delete(int id)
    {
        try
        {
            var entity = _unitOfWork.DynamicRepository<TEntity>().GetById(id);
            if(entity == null)
            {
                return new ResponseMessage("Record is not found!!");
            }
            _unitOfWork.DynamicRepository<TEntity>().DeleteById(id);
            _unitOfWork.Complete();
            return new ResponseMessage();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "GenericService.Delete");
            return new ResponseMessage(ex.Message);
        }
    }

    public virtual ResponseMessage<List<TResponse>> GetAll(params string[] includes)
    {
        try
        {
            var entity = _unitOfWork.DynamicRepository<TEntity>().GetAllWithInclude();
            var mapped = _mapper.Map<List<TEntity>, List<TResponse>>(entity);
            return new ResponseMessage<List<TResponse>>(mapped);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "GenericService.GetAll");
            return new ResponseMessage<List<TResponse>>(ex.Message);
        }
    }

    public virtual ResponseMessage<TResponse> GetById(int id, params string[] includes)
    {
        try
        {
            var entity = _unitOfWork.DynamicRepository<TEntity>().GetById(id);
            var mapped = _mapper.Map<TEntity, TResponse>(entity);
            return new ResponseMessage<TResponse>(mapped);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "GenericService.GetById");
            return new ResponseMessage<TResponse>(ex.Message);
        }
    }

    public virtual ResponseMessage Insert(TRequest request)
    {
        try
        {
            var entity = _mapper.Map<TRequest, TEntity>(request);
            _unitOfWork.DynamicRepository<TEntity>().Insert(entity);
            _unitOfWork.DynamicRepository<TEntity>().Save();
            return new ResponseMessage();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "GenericService.Insert");
            return new ResponseMessage(ex.Message);
        }
    }

    public virtual ResponseMessage Update(int id, TRequest request)
    {
        try
        {
            var exist = _unitOfWork.DynamicRepository<TEntity>().GetById(id);
            if(exist == null)
            {
                return new ResponseMessage("Record is not found!!");
            }
            var entity = _mapper.Map<TRequest,TEntity>(request);
            _unitOfWork.DynamicRepository<TEntity>().Update(entity);
            _unitOfWork.DynamicRepository<TEntity>().Save();
            return new ResponseMessage();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "GenericService.Update");
            return new ResponseMessage(ex.Message);
        }
    }

}
