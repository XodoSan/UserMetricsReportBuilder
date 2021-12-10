using Application.Generator;
using Application.Engine;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace UserMetricsReportBuilderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IFilterEngine _filterEngine;
        private readonly IExcelGenerator _excelGenerator;

        public ExcelController(
            IFilterEngine filterEngine,
            IExcelGenerator excelGenerator)
        {
            _filterEngine = filterEngine;
            _excelGenerator = excelGenerator;
        }

        [HttpGet]
        public void GenerateDoc()
        {
            int year = 2003;
            int metricType = 1;
            var metrics = _filterEngine.GetMetricsByFilter(year, metricType, SegmentType.Top);
            var reportExcel = _excelGenerator.DocFilling(metrics);

            System.IO.File.WriteAllBytes("C:/Users/Андрей/Downloads/" + "Report" + year + ".xlsx", reportExcel);
        }
    }
}
