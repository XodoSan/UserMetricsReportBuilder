using Application.Engine;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.MetricServices
{
    public class MetricService : IMetricService
    {
        private readonly IFilterEngine _filterEngine;

        public MetricService(
            IFilterEngine filterEngine)
        {
            _filterEngine = filterEngine;
        }

        public List<MetricByDay> GetMetricsByDay(int year, AllocationType allocationType)
        {
            IReadOnlyList<Metric> filteredMetrics = _filterEngine.GetMetricsByFilter(year, allocationType);
            Dictionary<string, int> aggreagatedMetrics = new Dictionary<string, int>();
            List<MetricByDay> result = new List<MetricByDay>();

            int daysInYear;
            if (DateTime.IsLeapYear(year)) daysInYear = 366;
            else daysInYear = 365;

            DateTime date = new DateTime(year, 1, 1);
            for (int i = 0; i < daysInYear; i++)
            {
                List<Metric> metricResult = filteredMetrics
                    .Where(metric => $"{metric.Timestamp:d}" == $"{date:d}")
                    .ToList();

                aggreagatedMetrics = _filterEngine.GetMetricCountByDescription(metricResult);
                result.Add(new MetricByDay(date, aggreagatedMetrics));

                date += TimeSpan.FromDays(1);
            }

            return result;
        }
    }
}

