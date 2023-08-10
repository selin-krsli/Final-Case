
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BuildingManagementSystem.Data;

[Table("Flat", Schema = "dbo")]
public class Flat
{
    public int FlatId { get; set; }
    public int BlockId { get; set; }
    public virtual Block Block { get; set; }
    public bool Status { get; set; }
    public string TypeOfFlat { get; set; }
    public int FloorNumber { get; set; }
    public int FlatNumber { get; set; }
    public bool OwnerorTenant { get; set; } //1-Owner 2-Tenant
    public int ResidentId { get; set; }
    public Resident Resident { get; set; }

}

public class FlatConfiguration : IEntityTypeConfiguration<Flat>
{
    public void Configure(EntityTypeBuilder<Flat> builder)
    {
        builder.Property(s => s.FlatId).IsRequired(true).UseIdentityColumn();
        builder.Property(s => s.BlockId).IsRequired(true);
        builder.Property(s => s.Status).IsRequired(true).HasDefaultValue(true);
        builder.Property(s => s.TypeOfFlat).IsRequired(true).HasMaxLength(6);
        builder.Property(s => s.FloorNumber).IsRequired(true);
        builder.Property(s => s.FloorNumber).IsRequired(true);
        builder.Property(s => s.OwnerorTenant).IsRequired(true).HasDefaultValue(true);
        builder.Property(s => s.ResidentId).IsRequired(true);

        builder.HasIndex(s=>s.BlockId).IsUnique(true);
        builder.HasIndex(s=>s.ResidentId).IsUnique(true);


        //builder.HasOne(s => s.Resident)
        //       .WithMany(s => s.Flats)
        //       .HasForeignKey(s => s.ResidentId)
        //       .IsRequired(true)
        //       .OnDelete(DeleteBehavior.Restrict);
    

        builder.HasOne(s=>s.Block)
            .WithMany(s=>s.Flats)
            .HasForeignKey(s=>s.BlockId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Restrict);
    }
}