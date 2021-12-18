using Domain.Entities;
using System.Collections.Generic;

namespace Application.Engine
{
    public interface IFilterEngine
    {
        IReadOnlyList<ExcelEntity> GetMetricsByFilter(int year, SegmentType segmentType);
    }
}
