using Domain.Entities;
using Domain.Repositories;
using System;
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

        public IReadOnlyList<Metric> GetMetrics(int year)
        {
            return _context.Set<Metric>()
                .Where(item => item.Timestamp.Year == year && item.Type == 5)
                .ToList();
        }

        public IReadOnlyList<Metric> GetMetricsByDate(DateTime date)
        {
            return _context.Set<Metric>()
                .Where(item => item.Timestamp.Date == date.Date && item.Type == 5)
                .ToList();
        }
    }
}
