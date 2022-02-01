using Domain.Entities;
using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class PropertySegmentRepository : IPropertySegmentRepository
    {
        private AppDBContext _context;

        public PropertySegmentRepository(AppDBContext context)
        {
            _context = context;
        }

        public List<PropertySegment> GetPropertySegments(SegmentType segment)
        {
            return _context.Set<PropertySegment>()
                .Where(item => item.SegmentType == segment)
                .ToList();
        }
    }
}
