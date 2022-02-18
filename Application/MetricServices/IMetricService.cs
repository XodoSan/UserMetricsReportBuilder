using Domain.Entities;
using System.Collections.Generic;

namespace Application.MetricServices
{
    public interface IMetricService
    {
        List<MetricByDay> GetMetricsByDay(int year, AllocationType segmentType);
    }
}
