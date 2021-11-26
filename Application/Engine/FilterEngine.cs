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

        public IReadOnlyList<Metric> GetMetricsByFilter(int year, int metricType, SegmentType segmentType)
        {
            IReadOnlyList<Metric> metricResult = new List<Metric>();
            IReadOnlyList<Metric> metrics = _metricRepository.GetMetrics(year, metricType);
            IReadOnlyList<PropertySegment> propertySegments = _propertySegmentRepository.GetPropertySegments(segmentType);

            var metricsById = metrics.Select(metric => metric.ProviderId);
            var propertySegmentsById = propertySegments.Select(propertySegment => propertySegment.PropertyId);
            var bothIds = metricsById.Intersect(propertySegmentsById).ToList();
            metricResult = metrics.Where(item => bothIds.Contains(item.ProviderId)).ToList();

            return metricResult;
        }
    }
}
