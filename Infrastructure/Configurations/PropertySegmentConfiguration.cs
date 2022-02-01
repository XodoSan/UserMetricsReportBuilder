using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class PropertySegmentConfiguration : IEntityTypeConfiguration<AllocationSegment>
    {
        public void Configure(EntityTypeBuilder<AllocationSegment> builder)
        {
            builder.ToTable("Provider")
                .HasKey(item => item.ProviderId);
            builder.Property(item => item.ProviderId).IsRequired();
            builder.Property(item => item.HotelKindId).IsRequired();
            builder.Property(item => item.LastUpdate);
            builder.Property(item => item.Mode);
            builder.Property(item => item.Name);
            builder.Property(item => item.PmsIntegrated);
            builder.Property(item => item.RegionId);
            builder.Property(item => item.SiteUrl);
            builder.Property(item => item.Stars);
            builder.Property(item => item.BookingFormStatus);
            builder.Property(item => item.BookingFormUrl);
            builder.Property(item => item.CityId);
            builder.Property(item => item.CountryId);
            builder.Property(item => item.CurrencyId);
            builder.Property(item => item.DevelopmentManagerId);
        }
    }
}
