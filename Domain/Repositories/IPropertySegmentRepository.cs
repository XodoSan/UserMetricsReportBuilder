﻿using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IPropertySegmentRepository
    {
        List<PropertySegment> GetPropertySegments(SegmentType segment);
    }
}