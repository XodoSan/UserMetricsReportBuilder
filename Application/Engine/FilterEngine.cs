using Domain.Entities;
using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Application.Engine
{
    public class FilterEngine : IFilterEngine
    {
        private readonly IMetricRepository _metricRepository;
        private readonly IPropertySegmentRepository _propertySegmentRepository;

        public FilterEngine(IMetricRepository metricRepository, IPropertySegmentRepository propertySegmentRepository)
        {
            _metricRepository = metricRepository;
            _propertySegmentRepository = propertySegmentRepository;
        }

        public IReadOnlyList<Metric> GetMetricsByFilter(int year, AllocationType allocationType)
        {
            IReadOnlyList<Metric> metrics = _metricRepository.GetMetrics(year);
            IReadOnlyList<AllocationSegment> propertySegments = _propertySegmentRepository.GetPropertySegments(allocationType);

            IEnumerable<int> metricsById = FilterNotRealCustomerMetrics(metrics);
            IEnumerable<int> propertySegmentsById = propertySegments.Select(propertySegment => propertySegment.ProviderId);

            List<int> bothIds = metricsById
                .Intersect(propertySegmentsById)
                .ToList();

            IReadOnlyList<Metric> metricResult = metrics
                .Where(item => bothIds.Contains(item.ProviderId))
                .ToList();

            return metricResult;
        }

        public Dictionary<string, int> GetMetricCountByDescription(IReadOnlyList<Metric> metricResult)
        {
            Dictionary<string, int> result = metricResult
                .GroupBy(metric => metric.Description.Contains("Statistic") ? metric.Description.Split(" ")[1] : metric.Description)
                .ToDictionary(item => item.Key, item => item.Count());

            return result;
        }

        private IEnumerable<int> FilterNotRealCustomerMetrics(IReadOnlyList<Metric> metrics)
        {
            const string TechnicalIp = "91.210.252.226";

            IEnumerable<int> metricsById = metrics
                .Where(metric => metric.IpAddress != TechnicalIp)
                .Select(metric => metric.ProviderId);

            return metricsById;
        }
    }
}