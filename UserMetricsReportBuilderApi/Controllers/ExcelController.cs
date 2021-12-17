using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application;

namespace UserMetricsReportBuilderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IExcelFileResultGenerator _excelFileResultGen;

        public ExcelController(
            IExcelFileResultGenerator excelFileResultGen)
        {
            _excelFileResultGen = excelFileResultGen;
        }

        [HttpGet("Reports/{year}/{metricType}/{segmentType}")]
        public FileResult GenerateDoc([FromRoute] int year, [FromRoute] int metricType, [FromRoute] SegmentType segmentType)
        {
            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Response.ContentType = contentType;
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

            FileResult resultFile = _excelFileResultGen.CreateFile(year, metricType, segmentType, contentType);

            return resultFile;
        }
    }
}
