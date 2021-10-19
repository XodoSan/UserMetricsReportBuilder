using Domain.Entities;
using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class MetricRepository : IMetricRepository
    {
        private AppDBContext _context;

        public MetricRepository(AppDBContext context)
        {
            _context = context;
        }

        public List<Metric> getMetrics(int year, int metricType)
        {
            return _context.Set<Metric>().Where(item => (item.Timestamp.Year == year) && (item.Type == metricType))
                .ToList();
        }
    }
}
