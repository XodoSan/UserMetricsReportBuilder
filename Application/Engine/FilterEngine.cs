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

            IReadOnlyList<ExcelEntity> groupedData = metricResult.GroupBy(metric => metric.Description
                .Substring(0, metric.Description
                .IndexOf(' ', metric.Description.IndexOf(' ') + 1)))
                .Where(description => description.Count() > 0)
                .Select(item => new ExcelEntity { Description = item.Key, Counter = item.Count() })
                .OrderByDescending(count => count.Counter)
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