using System;

namespace Domain.Entities
{
    public class Provider
    {
        public int ProviderId { get; }
        public string Name { get; protected set; }
        public string DevelopmentManagerId { get; protected set; }
        public string Mode { get; protected set; }
        public string BookingFormStatus { get; protected set; }
        public string SiteUrl { get; protected set; }
        public string BookingFormUrl { get; protected set; }
        public string PmsIntegrated { get; protected set; }
        public string Stars { get; protected set; }
        public ProviderType ProviderType { get; protected set; }
        public string CurrencyId { get; protected set; }
        public int CountryId { get; protected set; }
        public string RegionId { get; protected set; }
        public string CityId { get; protected set; }
        public DateTime LastUpdate { get; protected set; }
    }
}
