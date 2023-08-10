
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingManagementSystem.Data;

[Table("CardInformation", Schema = "dbo")]
public class CardInformation
{
    public int CardInformationId { get; set; }

    public int ResidentId { get; set; }
    public Resident Resident { get; set; }
    public string ReferenceNumber { get; set; }
    public string CVV { get; set; }
    public decimal Balance { get; set; }
    public DateTime ExpiryDate { get; set; }

}
public class CardInformationConfiguration : IEntityTypeConfiguration<CardInformation>
{
    public void Configure(EntityTypeBuilder<CardInformation> builder)
    {
        builder.Property(s=>s.CardInformationId).IsRequired(true).UseIdentityColumn();
        builder.Property(s=>s.ResidentId).IsRequired(true);
        builder.Property(s=>s.ReferenceNumber).IsRequired(true).HasMaxLength(50);
        builder.Property(s=>s.ExpiryDate).IsRequired(true);
        builder.Property(s=>s.CVV).IsRequired(true).IsFixedLength().HasMaxLength(3);

        builder.HasIndex(s=>s.ResidentId).IsUnique();
        builder.HasIndex(s=>s.ReferenceNumber).IsUnique();
        builder.HasIndex(s=>s.CVV).IsUnique();

    }
}
