
using Microsoft.EntityFrameworkCore;

namespace BuildingManagementSystem.Data;

public class ManagementDbContext:DbContext
{
    public ManagementDbContext(DbContextOptions<ManagementDbContext> options):base(options)
    {
        
    }

    public DbSet<Resident> Residents { get; set; }
    public DbSet<CardInformation> CardInformations { get; set; }
    public DbSet<Block> Blocks { get; set; }
    public DbSet<Flat> Flats { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceType> InvoiceTypes { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserLog> UserLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ResidentConfiguration());
        modelBuilder.ApplyConfiguration(new BlockConfiguration());
        modelBuilder.ApplyConfiguration(new CardInformationConfiguration());
        modelBuilder.ApplyConfiguration(new FlatConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MessageConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        modelBuilder.ApplyConfiguration(new VehicleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserLogConfiguration());

    }
}
