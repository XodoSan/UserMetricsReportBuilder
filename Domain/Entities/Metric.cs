using System;

namespace Domain.Entities
{
    public class Metric
    {
        public int MetricId { get; }
        public int ProviderId { get; set; }
        public int Type { get; set; }
        public DateTime Timestamp { get; set; }
        public string Description { get; set; }
        public string IpAddress { get; set; }
        public string UserName { get; set; }
    }
}
