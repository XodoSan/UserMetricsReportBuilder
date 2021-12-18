using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application
{
    public interface IExcelFileResultGen
    {
        public FileResult FileCreating(int year, int metricType, SegmentType segmentType, string contentType);
    }
}
