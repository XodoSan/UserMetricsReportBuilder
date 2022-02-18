using Domain.Entities;
using Domain.Repositories;
using System;
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

        public List<AllocationSegment> GetPropertySegments(AllocationType segment)
        {
            return _context.Set<AllocationSegment>()
                .Where(item => item.HotelKindId == (char)segment)
                .ToList();
        }
    }
}
