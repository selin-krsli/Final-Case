
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingManagementSystem.Data;

public class UserLog
{
    public int UserLogId { get; set; }
    public string UserName { get; set; }
    public string InsertUser { get; set; }
    public DateTime InsertDate { get; set; }
    public string LogType { get; set; }
}

public class UserLogConfiguration : IEntityTypeConfiguration<UserLog>
{
    public void Configure(EntityTypeBuilder<UserLog> builder)
    {
        builder.Property(s=>s.UserLogId).IsRequired(true).UseIdentityColumn();
        builder.Property(s => s.UserName).IsRequired(true).HasMaxLength(30);
        builder.Property(s => s.InsertDate).IsRequired(true);
        builder.Property(s => s.InsertUser).IsRequired(true).HasMaxLength(30);
        builder.Property(s => s.LogType).IsRequired(true).HasMaxLength(20);
    }
}
