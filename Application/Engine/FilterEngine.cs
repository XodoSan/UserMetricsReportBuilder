using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Engine
{
    public class FilterEngine : IFilterEngine
    {
        private readonly IMetricRepository _metricRepository;
        private readonly IProviderRepository _providerRepository;

        public FilterEngine(IMetricRepository metricRepository, IProviderRepository providerRepository)
        {
            _metricRepository = metricRepository;
            _providerRepository = providerRepository;
        }

        public MetricByDay GetMetricsByDate(DateTime date, IEnumerable<ProviderType> providerTypes)
        {
            IReadOnlyList<Metric> metrics = _metricRepository.GetMetricsByDate(date);
            IReadOnlyList<Provider> providers = _providerRepository.GetProvidersByProviderTypes(providerTypes);

            IEnumerable<int> metricProviderIds = GetRealMetricIds(metrics);
            IEnumerable<int> providerIds = providers.Select(propertySegment => propertySegment.ProviderId);

            List<int> bothIds = metricProviderIds
                .Intersect(providerIds)
                .ToList();

            IReadOnlyList<Metric> metricResult = metrics
                .Where(item => bothIds.Contains(item.ProviderId))
                .ToList();

            Dictionary<string, int> aggreagatedMetrics = GetMetricCountByDescription(metricResult);
            List<MetricCount> metricCounts = aggreagatedMetrics
                .Select(item => new MetricCount(item.Key, item.Value))
                .ToList();

            MetricByDay result = new MetricByDay(date, metricCounts);

            return result;
        }

        private Dictionary<string, int> GetMetricCountByDescription(IReadOnlyList<Metric> metricResult)
        {
            Dictionary<string, int> result = metricResult
                .GroupBy(metric => metric.Description.Contains("Statistic") 
                ? metric.Description.Split(" ")[1] : metric.Description)
                .ToDictionary(item => item.Key.Trim(':'), item => item.Count());

            return result;
        }

        private IEnumerable<int> GetRealMetricIds(IReadOnlyList<Metric> metrics)
        {
            const string TechnicalIp = "91.210.252.226";

            IEnumerable<int> metricsById = metrics
                .Where(metric => metric.IpAddress != TechnicalIp)
                .Select(metric => metric.ProviderId);

            return metricsById;
        }
    }
}