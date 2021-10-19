using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IMetricRepository
    {
        List<Metric> getMetrics(int year, int metricType);
    }
}
