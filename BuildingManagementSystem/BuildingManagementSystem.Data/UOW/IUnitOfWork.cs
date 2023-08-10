
using BuildingManagementSystem.Data.Repository;

namespace BuildingManagementSystem.Data;

public interface IUnitOfWork
{
    void Complete();
    void CompleteWithTransaction();
    IGenericRepository<Entity> DynamicRepository<Entity>() where Entity : class;

    IGenericRepository<Resident> ResidentRepository { get; }
    IGenericRepository<Flat> FlatRepository { get; }
    IGenericRepository<Block> BlockRepository { get; }
    IGenericRepository<Invoice> InvoiceRepository { get; }
    IGenericRepository<InvoiceType> InvoiceTypeRepository { get; }
    IGenericRepository<Payment> PaymentRepository { get; }
    IGenericRepository<Vehicle> VehicleRepository { get; }
    IGenericRepository<CardInformation> CardInformationRepository { get; }
    IGenericRepository<Message> MessageRepository { get; }
    IGenericRepository<User> UserRepository { get; }
    IGenericRepository<UserLog> UserLogRepository { get; }
}
