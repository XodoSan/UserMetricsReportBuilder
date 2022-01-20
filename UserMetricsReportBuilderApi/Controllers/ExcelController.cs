using Application;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace UserMetricsReportBuilderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IFileResultGenerator _fileResultGenerator;

        public ExcelController(IFileResultGenerator excelFileResultGen)
        {
            _fileResultGenerator = excelFileResultGen;
        }

        [HttpGet("Reports/{year}/{segmentType}")]
        public FileResult GenerateDoc([FromRoute] int year, [FromRoute] SegmentType segmentType)
        {
            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Response.ContentType = contentType;
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

            FileResult resultFile = _fileResultGenerator.CreateFile(year, segmentType, contentType);

            return resultFile;
        }
    }
}
