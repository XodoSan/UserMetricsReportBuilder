using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IMetricRepository
    {
        IReadOnlyList<Metric> GetMetrics(int year, int metricType);
    }
}