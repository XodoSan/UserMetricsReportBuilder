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

        public FileResult CreateFile(int year, SegmentType segmentType, string contentType)
        {
            IReadOnlyList<ExcelEntity> excelEntities = _filterEngine.GetMetricsByFilter(year, segmentType);
            byte[] reportExcel = _excelGenerator.Generate(excelEntities);

            var fileContentResult = new FileContentResult(reportExcel, contentType)
            {
                FileDownloadName = $"{DateTime.Now:d} Report" + ".xls"
            };

            return fileContentResult;
        }
    }
}
