using Application;
using Application.Engine;
using Application.Generator;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure
{
    public class ExcelFileResultGen : IExcelFileResultGen
    {
        private readonly IFilterEngine _filterEngine;
        private readonly IExcelGenerator _excelGenerator;

        public ExcelFileResultGen(
            IFilterEngine filterEngine,
            IExcelGenerator excelGenerator)
        {
            _filterEngine = filterEngine;
            _excelGenerator = excelGenerator;
        }

        public FileResult FileCreating(int year, int metricType, SegmentType segmentType, string contentType)
        {
            var metrics = _filterEngine.GetMetricsByFilter(year, metricType, segmentType);
            var reportExcel = _excelGenerator.DocFilling(metrics);

            var fileContentResult = new FileContentResult(reportExcel, contentType)
            {
                FileDownloadName = "Report " + year + ".xls"
            };

            return fileContentResult;
        }
    }
}
