using Domain.Entities;
using System.Collections.Generic;

namespace Application
{
    public interface IFilterEngine
    {
        IReadOnlyList<Metric> GetMetricsByFilter(int year, int metricType, SegmentType segmentType);
    }
}
