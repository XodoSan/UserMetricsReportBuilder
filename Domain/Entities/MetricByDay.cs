using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class MetricByDay
    {
        public MetricByDay(DateTime dateTime, List<MetricCount> metricCounts)
        {
            Timestamp = dateTime;
            MetricCounts = metricCounts;
        }

        public DateTime Timestamp { get; private set; }
        public List<MetricCount> MetricCounts { get; private set; }
    }
}
