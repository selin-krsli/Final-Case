
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingManagementSystem.Data;

[Table("Block", Schema = "dbo")]
public class Block
{
    public int BlockId { get; set; }
    public string BlockName { get; set; }

    public virtual List<Flat> Flats { get; set; } 
}

public class BlockConfiguration : IEntityTypeConfiguration<Block>
{
    public void Configure(EntityTypeBuilder<Block> builder)
    {
        builder.Property(s => s.BlockId).IsRequired(true).UseIdentityColumn();
        builder.Property(s => s.BlockName).IsRequired(true).HasMaxLength(15);

        builder.HasIndex(s => s.BlockId);

    }
}