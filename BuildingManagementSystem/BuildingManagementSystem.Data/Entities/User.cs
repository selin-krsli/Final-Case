
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingManagementSystem.Data;

[Table("User", Schema = "dbo")]
public class User
{   
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime LastActivity { get; set; }
    public string Role { get; set; }
    public int Status { get; set; }
    public int PasswordRetryCount { get; set; }
}
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {        
        builder.Property(s => s.UserId).IsRequired(true).UseIdentityColumn();
        builder.Property(s=>s.UserName).IsRequired(true).HasMaxLength(30); 
        builder.Property(s=>s.FirstName).IsRequired(true).HasMaxLength(30); 
        builder.Property(s=>s.LastName).IsRequired(true).HasMaxLength(30); 
        builder.Property(s=>s.Email).IsRequired(true).HasMaxLength(30); 
        builder.Property(s=>s.Password).IsRequired(true).HasMaxLength(50); 
        builder.Property(s=>s.LastActivity).IsRequired(true); 
        builder.Property(s=>s.PasswordRetryCount).IsRequired(true); 
        builder.Property(s=>s.Role).IsRequired(true).HasMaxLength(30); 
        builder.Property(s=>s.Status).IsRequired(true);

        builder.HasIndex(s => s.UserName).IsUnique(true);
    }
}