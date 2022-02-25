using Domain.Entities;
using System.Collections.Generic;

namespace Application.MetricServices
{
    public interface IMetricService
    {
        IReadOnlyList<MetricByDay> GetMetricsByDay(int year, IEnumerable<ProviderType> providerTypes);
    }
}
