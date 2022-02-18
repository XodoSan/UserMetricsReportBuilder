using Application;
using Application.MetricServices;
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
        private readonly IMetricService _metricService;
        private readonly IExcelGenerator _excelGenerator;

        public FileResultGenerator(
            IMetricService metricService,
            IExcelGenerator excelGenerator)
        {
            _metricService = metricService;
            _excelGenerator = excelGenerator;
        }

        public FileResult CreateFile(int year, IEnumerable<ProviderType> providerTypes, string contentType)
        {
            IReadOnlyList<MetricByDay> metricsByDays = _metricService.GetMetricsByDay(year, providerTypes);
            List<MetricByDay> resultData = metricsByDays.Where(metricByDay => metricByDay.MetricCounts.Count > 0).ToList();

            List<ExcelEntity> excelEntities = new List<ExcelEntity>();
            excelEntities.Add(new ExcelEntity(resultData[0].MetricCounts[0].Description, 0));

            for (int i = 0; i < resultData.Count(); i++)
            {
                for (int j = 0; j < resultData[i].MetricCounts.Count(); j++)
                {
                    if (resultData[i].MetricCounts[j].Description != excelEntities[0].Description)
                    {
                        excelEntities.Add(new ExcelEntity(resultData[i].MetricCounts[j].Description, resultData[i].MetricCounts[j].Counter));
                    }
                    else if (resultData[i].MetricCounts[j].Description == excelEntities[0].Description)
                    {
                        excelEntities[0].Counter += resultData[i].MetricCounts[j].Counter;
                    }
                }
            }

            byte[] reportExcel = _excelGenerator.Generate(excelEntities);

            var fileContentResult = new FileContentResult(reportExcel, contentType)
            {
                FileDownloadName = $"{DateTime.Now:d} Report" + ".xlsx"
            };

            return fileContentResult;
        }
    }
}
