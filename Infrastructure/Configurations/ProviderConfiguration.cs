using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable(nameof(Provider)).HasKey(item => item.ProviderId);
            builder.Property(item => item.ProviderId).IsRequired();
            builder.Property(item => item.ProviderType)
                .HasColumnName("HotelKindId").IsRequired();
        }
    }
}
