using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class MetricByDay
    {
        public MetricByDay(DateTime dateTime, Dictionary<string, int> metrics)
        {
            Timestamp = dateTime;
            Metrics = metrics;
        }

        public DateTime Timestamp { get; private set; }
        public Dictionary<string, int> Metrics { get; private set; }
    }
}
