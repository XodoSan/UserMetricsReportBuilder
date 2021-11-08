using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class PropertySegmentConfiguration : IEntityTypeConfiguration<PropertySegment>
    {
        public void Configure(EntityTypeBuilder<PropertySegment> builder)
        {
            builder.ToTable(nameof(PropertySegment))
                .HasKey(item => item.PropertyId);
            builder.Property(item => item.PropertyId).IsRequired()
            builder.Property(item => item.SegmentType).IsRequired();
        }
    }
}
