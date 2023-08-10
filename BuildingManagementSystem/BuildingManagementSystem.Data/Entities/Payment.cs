
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingManagementSystem.Data;

[Table("Payment", Schema = "dbo")]
public class Payment
{
    public int PaymentId { get; set; }
    public int ResidentId { get; set; }
    public Resident Resident { get; set; }
    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
    public decimal PaymentAmount { get; set; }
    public DateTime DueDate { get; set; }
}
public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.Property(s => s.PaymentId).IsRequired(true).UseIdentityColumn();
        builder.Property(s => s.ResidentId).IsRequired(true);
        builder.Property(s => s.InvoiceId).IsRequired(true);
        builder.Property(s => s.PaymentAmount).IsRequired(true).HasPrecision(15,4).HasDefaultValue(0);
        builder.Property(s => s.DueDate).IsRequired(true);

        builder.HasIndex(s => s.ResidentId).IsUnique();
        builder.HasIndex(s => s.InvoiceId).IsUnique();

        //builder.HasOne(s => s.Resident)
        //       .WithMany(s => s.Payments)
        //       .HasForeignKey(s => s.ResidentId)
        //       .IsRequired(true)
        //       .OnDelete(DeleteBehavior.Restrict);
    }
}