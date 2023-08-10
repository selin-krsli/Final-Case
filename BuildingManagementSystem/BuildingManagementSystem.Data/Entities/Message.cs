

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingManagementSystem.Data;

[Table("Message", Schema = "dbo")]
public class Message
{
    public int MessageId { get; set; }
    public int ResidentId { get; set; } 
    public string Content { get; set; }
    public string Subject { get; set; }
    public bool IsRead { get; set; }
    public DateTime SendingTime { get; set; }

    //Navigation Properties
   public virtual Resident Resident { get; set; }
}
public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.Property(s => s.MessageId).IsRequired(true).UseIdentityColumn();
        builder.Property(s => s.ResidentId).IsRequired(true);
        builder.Property(s => s.Content).IsRequired(true).HasMaxLength(500);
        builder.Property(s => s.Subject).IsRequired(true).HasMaxLength(100);
        builder.Property(s => s.IsRead).IsRequired(true).HasDefaultValue(true);
        builder.Property(s => s.SendingTime).IsRequired(true);

        builder.HasIndex(s => s.ResidentId);

        builder.HasOne(s=>s.Resident)
                .WithMany(s=>s.Messages)
                .HasForeignKey(s=>s.ResidentId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
    }
}
