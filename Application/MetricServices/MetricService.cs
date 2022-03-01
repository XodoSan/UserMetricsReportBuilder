using Application.Engine;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.MetricServices
{
    public class MetricService : IMetricService
    {
        private readonly IFilterEngine _filterEngine;

        public MetricService(IFilterEngine filterEngine)
        {
            _filterEngine = filterEngine;
        }

        public IReadOnlyList<MetricByDay> GetMetricsByDays(int year, IEnumerable<ProviderType> providerTypes)
        {
            List<MetricByDay> result = new List<MetricByDay>();

            int daysInYear;
            if (DateTime.IsLeapYear(year))
            {
                daysInYear = 366;
            }
            else
            {
                daysInYear = 365;
            }

            DateTime date = new DateTime(year, 1, 1);
            for (int i = 0; i < daysInYear; i++)
            {
                result.Add(_filterEngine.GetMetricsByDate(date, providerTypes));

                date += TimeSpan.FromDays(1);
            }

            return result;
        }
    }
}

