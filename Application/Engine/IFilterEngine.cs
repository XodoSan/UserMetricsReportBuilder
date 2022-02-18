using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Engine
{
    public interface IFilterEngine
    {
        MetricByDay GetMetricsByDate(DateTime date, IEnumerable<ProviderType> providerTypes);
    }
}
