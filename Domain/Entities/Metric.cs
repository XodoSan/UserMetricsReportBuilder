using System;

namespace Domain.Entities
{
    public class Metric
    {
        public int MetricId { get; }
        public int ProviderId { get; protected set; }
        public int Type { get; protected set; }
        public DateTime Timestamp { get; protected set; }
        public string Description { get; protected set; }
        public string IpAddress { get; protected set; }
        public string UserName { get; protected set; }
    }
}
