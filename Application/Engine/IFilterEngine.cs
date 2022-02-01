using Domain.Entities;
using System.Collections.Generic;

namespace Application.Engine
{
    public interface IFilterEngine
    {
        IReadOnlyList<Metric> GetMetricsByFilter(int year, AllocationType segmentType);
        Dictionary<string, int> GetMetricCountByDescription(IReadOnlyList<Metric> merics);
    }
}
