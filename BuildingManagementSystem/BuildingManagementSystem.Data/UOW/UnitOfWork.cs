
using BuildingManagementSystem.Data.Repository;
using Serilog;

namespace BuildingManagementSystem.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ManagementDbContext _dbContext;
    public UnitOfWork(ManagementDbContext dbContext)
    {

        _dbContext = dbContext;

        ResidentRepository = new GenericRepository<Resident>(_dbContext);
        FlatRepository = new GenericRepository<Flat>(_dbContext);
        BlockRepository = new GenericRepository<Block>(_dbContext);
        InvoiceRepository = new GenericRepository<Invoice>(_dbContext);
        InvoiceTypeRepository = new GenericRepository<InvoiceType>(_dbContext);
        PaymentRepository = new GenericRepository<Payment>(_dbContext);
        VehicleRepository = new GenericRepository<Vehicle>(_dbContext);
        CardInformationRepository = new GenericRepository<CardInformation>(_dbContext);
        MessageRepository = new GenericRepository<Message>(_dbContext);
        UserRepository = new GenericRepository<User>(_dbContext);
        UserLogRepository = new GenericRepository<UserLog>(_dbContext);

    }
    public void Complete()
    {
        _dbContext.SaveChanges();
    }

    public void CompleteWithTransaction()
    {
       using(var dbTransaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                _dbContext.SaveChanges();
                dbTransaction.Commit();
            }
            catch (Exception ex)
            {

                dbTransaction.Rollback();
                Log.Error(ex, "CompleteWithTransaction");
            }
        }
    }

    public IGenericRepository<Entity> DynamicRepository<Entity>() where Entity : class
    {
        return new GenericRepository<Entity>(_dbContext);
    }


    public IGenericRepository<Resident> ResidentRepository {get; private set;}

    public IGenericRepository<Flat> FlatRepository { get; private set; }

    public IGenericRepository<Block> BlockRepository { get; private set; }

    public IGenericRepository<Invoice> InvoiceRepository { get; private set; }

    public IGenericRepository<InvoiceType> InvoiceTypeRepository { get; private set; }

    public IGenericRepository<Payment> PaymentRepository { get; private set; }

    public IGenericRepository<Vehicle> VehicleRepository { get; private set; }

    public IGenericRepository<CardInformation> CardInformationRepository { get; private set; }

    public IGenericRepository<Message> MessageRepository { get; private set; }
    public IGenericRepository<User> UserRepository { get; private set; }
    public IGenericRepository<UserLog> UserLogRepository { get; private set; }

}
