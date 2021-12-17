using Application;
using Application.Engine;
using Application.Generator;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public class ExcelFileResultGenerator : IExcelFileResultGenerator
    {
        private readonly IFilterEngine _filterEngine;
        private readonly IExcelGenerator _excelGenerator;

        public ExcelFileResultGenerator(
            IFilterEngine filterEngine,
            IExcelGenerator excelGenerator)
        {
            _filterEngine = filterEngine;
            _excelGenerator = excelGenerator;
        }

        public FileResult CreateFile(int year, int metricType, SegmentType segmentType, string contentType)
        {
            IReadOnlyList<Metric> metrics = _filterEngine.GetMetricsByFilter(year, metricType, segmentType);
            byte[] reportExcel = _excelGenerator.Generate(metrics);

            var fileContentResult = new FileContentResult(reportExcel, contentType)
            {
                FileDownloadName = $"{DateTime.Now:d} Report" + ".xls"
            };

            return fileContentResult;
        }
    }
}
