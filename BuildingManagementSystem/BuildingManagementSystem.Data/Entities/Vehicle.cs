
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingManagementSystem.Data;

[Table("Vehicle", Schema = "dbo")]
public class Vehicle
{
    public int VehicleId { get; set; }
    public int ResidentId { get; set; }
    public virtual Resident Resident { get; set; }
    public string VehicleBrand { get; set; }
    public string VehicleModel { get; set; }
    public string VehiclePlate { get; set; }

}
public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.Property(s => s.VehicleId).IsRequired(true).UseIdentityColumn();
        builder.Property(s => s.ResidentId).IsRequired(true);
        builder.Property(s => s.VehicleBrand).IsRequired(true).HasMaxLength(20);
        builder.Property(s => s.VehicleModel).IsRequired(true).HasMaxLength(20);
        builder.Property(s => s.VehiclePlate).IsRequired(true).HasMaxLength(8);

        builder.HasIndex(s => s.ResidentId);
        builder.HasIndex(s => s.VehiclePlate).IsUnique();

        builder.HasOne(s=>s.Resident)
               .WithMany(s => s.Vehicles)
               .HasForeignKey(s => s.ResidentId)
               .IsRequired(true)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
