
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingManagementSystem.Data;

[Table("Invoice", Schema = "dbo")]
public class Invoice
{
    public int InvoiceId { get; set; }
    public int InvoiceTypeId { get; set; }
    public virtual InvoiceType InvoiceType { get; set; }

    public int ResidentId { get; set; }

    public decimal Amount { get; set; }
    public int Month { get; set; }
    public bool IsPaid { get; set; }

    public virtual Resident Resident { get; set; }
    public virtual List<Payment> Payments { get; set; }
}

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.Property(s => s.InvoiceId).IsRequired(true).UseIdentityColumn();
        builder.Property(s => s.InvoiceTypeId).IsRequired(true);
        builder.Property(s => s.ResidentId).IsRequired(true);
        builder.Property(s => s.Amount).IsRequired(true).HasPrecision(15,4).HasDefaultValue(0);
        builder.Property(s => s.Month).IsRequired(true);
        builder.Property(s => s.IsPaid).IsRequired(true).HasDefaultValue(0);

        builder.HasIndex(s=>s.ResidentId).IsUnique(true);
        builder.HasIndex(s=>s.InvoiceTypeId).IsUnique(true);

        builder.HasOne(s => s.InvoiceType)
               .WithMany(s=>s.Invoices)
               .HasForeignKey(s => s.InvoiceTypeId)
               .IsRequired(true);

        //builder.HasOne(s=>s.Resident)
        //    .WithMany(s=>s.Invoices)
        //    .HasForeignKey(s=>s.ResidentId)
        //    .IsRequired(true)
        //    .OnDelete(DeleteBehavior.Restrict);


        //builder.HasMany(s => s.Payments)
        //       .WithOne(s => s.Invoice)
        //       .HasForeignKey(s => s.InvoiceId)
        //       .IsRequired(true);
    }
}
