using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class MetricConfiguration : IEntityTypeConfiguration<Metric>
    {
        public void Configure(EntityTypeBuilder<Metric> builder)
        {
            builder.ToTable(nameof(Metric)).HasKey(item => item.MetricId);
            builder.Property(item => item.MetricId).IsRequired();
            builder.Property(item => item.ProviderId).IsRequired();
            builder.Property(item => item.Type).IsRequired();
            builder.Property(item => item.Timestamp);
            builder.Property(item => item.Description);
            builder.Property(item => item.IpAddress);
            builder.Property(item => item.UserName);
        }
    }
}
