using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application;

namespace UserMetricsReportBuilderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IExcelFileResultGen _excelFileResultGen;

        public ExcelController(
            IExcelFileResultGen excelFileResultGen)
        {
            _excelFileResultGen = excelFileResultGen;
        }

        [HttpGet("Reports/{year}/{metricType}/{segmentType}")]
        public FileResult GenerateDoc(int year, int metricType, SegmentType segmentType)
        {
            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Response.ContentType = contentType;
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

            var resultFile = _excelFileResultGen.FileCreating(year, metricType, segmentType, contentType);

            return resultFile;
        }
    }
}
