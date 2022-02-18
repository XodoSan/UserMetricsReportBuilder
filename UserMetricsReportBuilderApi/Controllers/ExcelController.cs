using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application;
using System.Collections.Generic;
using Application.MetricServices;

namespace UserMetricsReportBuilderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IFileResultGenerator _excelFileResultGen;
        private readonly IMetricService _metricService;

        public ExcelController(
            IFileResultGenerator excelFileResultGen,
            IMetricService metricService)
        {
            _excelFileResultGen = excelFileResultGen;
            _metricService = metricService;
        }

        [HttpGet("CreateDoc/{year}/{allocationType}")]
        public FileResult GenerateDoc([FromRoute] int year, [FromRoute] AllocationType allocationType)
        {
            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Response.ContentType = contentType;
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

            FileResult resultFile = _excelFileResultGen.CreateFile(year, allocationType, contentType);

            return resultFile;
        }

        [HttpGet("GetData/{year}/{allocationType}")]
        public List<MetricByDay> GetMetricsByDay([FromRoute] int year, [FromRoute] AllocationType allocationType)
        {
            List<MetricByDay> resultData = _metricService.GetMetricsByDay(year, allocationType);

            return resultData;
        }
    }
}
