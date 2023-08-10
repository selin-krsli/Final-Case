using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BuildingManagementSystem.Data;

[Table("Resident", Schema = "dbo")]
public class Resident
{
    public int ResidentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TCNo { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public string VehiclePlate { get; set; }


    // Navigation Properties
    [JsonIgnore]
    public virtual List<Flat> Flats { get; set; }
    public virtual List<Invoice> Invoices { get; set; }
    public virtual List<Payment> Payments { get; set; } 
    public virtual List<Message> Messages { get; set; } 
    public virtual List<Vehicle> Vehicles { get; set; }
}

public class ResidentConfiguration : IEntityTypeConfiguration<Resident>
{

    public void Configure(EntityTypeBuilder<Resident> builder)
    {
        builder.Property(s => s.ResidentId).IsRequired(true).UseIdentityColumn();
        builder.Property(s => s.FirstName).IsRequired(true).HasMaxLength(20);
        builder.Property(s => s.LastName).IsRequired(true).HasMaxLength(20);
        builder.Property(s => s.TCNo).IsRequired(true).IsFixedLength().HasMaxLength(11);
        builder.Property(s => s.Email).IsRequired(true).HasMaxLength(30);
        builder.Property(s => s.Phone).IsRequired(true).HasMaxLength(11);
        builder.Property(s => s.Password).IsRequired(true);
        builder.Property(s => s.VehiclePlate).IsRequired(true).HasMaxLength(8);

        //builder.HasCheckConstraint("CK_Resident_Email", "Email LIKE '%@%'");
        //builder.HasCheckConstraint("CK_Resident_Phone", "Phone LIKE '+[0-9]%' OR Phone LIKE '0[0-9]%'");

        builder.HasIndex(s => s.TCNo).IsUnique(true);
        builder.HasIndex(s => s.VehiclePlate).IsUnique(true);

        builder.HasMany(s => s.Flats)
               .WithOne(s => s.Resident)
               .HasForeignKey(s => s.ResidentId)
               .IsRequired(true);

        builder.HasMany(s=>s.Invoices) 
               .WithOne(s => s.Resident)
               .HasForeignKey(s=>s.ResidentId)
               .IsRequired(true);

        builder.HasMany(s=>s.Payments)
               .WithOne(s => s.Resident)
               .HasForeignKey(s => s.ResidentId)
               .IsRequired(true);

        builder.HasMany(s => s.Messages)
                .WithOne(s => s.Resident)
                .HasForeignKey(s => s.ResidentId)
                .IsRequired(true);
    }
}
