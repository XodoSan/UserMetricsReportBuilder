using Domain.Entities;
using System.Collections.Generic;

namespace Application.MetricServices
{
    public interface IMetricService
    {
        IReadOnlyList<MetricByDay> GetMetricsByDays(int year, IEnumerable<ProviderType> providerTypes);
    }
}
