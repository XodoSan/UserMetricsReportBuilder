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

        public IReadOnlyList<ExcelEntity> GetMetricsByFilter(int year, SegmentType segmentType)
        {
            IReadOnlyList<Metric> metrics = _metricRepository.GetMetrics(year);
            IReadOnlyList<PropertySegment> propertySegments = _propertySegmentRepository.GetPropertySegments(segmentType);

            IEnumerable<int> metricsById = metrics
                .Where(metric => metric.IpAddress != "91.210.252.226")
                .Select(metric => metric.ProviderId);
            IEnumerable<int> propertySegmentsById = propertySegments.Select(propertySegment => propertySegment.PropertyId);
            List<int> bothIds = metricsById.Intersect(propertySegmentsById).ToList();
            IReadOnlyList<Metric> metricResult = metrics.Where(item => bothIds.Contains(item.ProviderId)).ToList();

            IReadOnlyList<ExcelEntity> groupedData = metricResult.GroupBy(metric => metric.Description)
                .Where(description => description.Count() > 1)
                .Select(y => new ExcelEntity { Description = y.Key, Counter = y.Count() })
                .ToList();

            return groupedData;
        }
    }
}


public class ExcelEntity
{
    public string Description { get; set; }
    public int Counter { get; set; }
}