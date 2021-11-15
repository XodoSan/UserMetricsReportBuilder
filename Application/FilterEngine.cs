using Domain.Entities;
using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Application
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
            IEnumerable<int> bothIds = new List<int>();
            IReadOnlyList<Metric> metricResult = new List<Metric>();
            IReadOnlyList<Metric> metrics = _metricRepository.GetMetrics(year, metricType);
            IReadOnlyList<PropertySegment> propertySegments = _propertySegmentRepository.GetPropertySegments(segmentType);

            bothIds = metrics.Select(a => a.ProviderId).Intersect(propertySegments.Select(a => a.PropertyId));
            metricResult = (IReadOnlyList<Metric>)metrics.Where(item => bothIds.Contains(item.ProviderId));

            return metricResult;
        }
    }
}
