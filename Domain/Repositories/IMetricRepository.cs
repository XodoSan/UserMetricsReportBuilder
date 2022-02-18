using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IMetricRepository
    {
        IReadOnlyList<Metric> GetMetrics(int year);
        IReadOnlyList<Metric> GetMetricsByDate(DateTime date);
    }
}