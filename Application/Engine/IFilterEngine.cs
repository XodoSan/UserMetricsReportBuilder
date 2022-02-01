using Domain.Entities;
using System.Collections.Generic;

namespace Application.Engine
{
    public interface IFilterEngine
    {
        Dictionary<string, int> GetMetricsByFilter(int year, SegmentType segmentType);
    }
}
