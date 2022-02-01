using Application;
using Application.Engine;
using Domain.Entities;
using Infrastructure.Generator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.ResultGeneration
{
    public class FileResultGenerator : IFileResultGenerator
    {
        private readonly IFilterEngine _filterEngine;
        private readonly IExcelGenerator _excelGenerator;

        public FileResultGenerator(
            IFilterEngine filterEngine,
            IExcelGenerator excelGenerator)
        {
            _filterEngine = filterEngine;
            _excelGenerator = excelGenerator;
        }

        public FileResult CreateFile(int year, AllocationType allocationType, string contentType)
        {
            IReadOnlyList<Metric> metricResult = _filterEngine.GetMetricsByFilter(year, allocationType);
            Dictionary<string, int> aggreagatedMetrics = _filterEngine.GetMetricCountByDescription(metricResult);

            List<ExcelEntity> excelEntities = aggreagatedMetrics
                .Select(item => new ExcelEntity(item.Key, item.Value))
                .OrderByDescending(item => item.Counter)
                .ToList();
            byte[] reportExcel = _excelGenerator.Generate(excelEntities);

            var fileContentResult = new FileContentResult(reportExcel, contentType)
            {
                FileDownloadName = $"{DateTime.Now:d} Report" + ".xlsx"
            };

            return fileContentResult;
        }
    }
}
