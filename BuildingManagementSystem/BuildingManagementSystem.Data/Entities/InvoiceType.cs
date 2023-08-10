
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingManagementSystem.Data;

[Table("InvoiceType", Schema = "dbo")]
public class InvoiceType
{
    public int InvoiceTypeId { get; set; }
    public string InvoiceTypeName { get; set; }
    public virtual List<Invoice> Invoices { get; set; }
}
public class InvoiceTypeConfiguration : IEntityTypeConfiguration<InvoiceType>
{
    public void Configure(EntityTypeBuilder<InvoiceType> builder)
    {
       builder.Property(s=>s.InvoiceTypeId).IsRequired(true).UseIdentityColumn(); 
       builder.Property(s=>s.InvoiceTypeName).IsRequired(true).HasMaxLength(20);

    }
}