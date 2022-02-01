using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IPropertySegmentRepository
    {
        List<AllocationSegment> GetPropertySegments(AllocationType allocationType);
    }
}
