using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application;
using System.Collections.Generic;

namespace UserMetricsReportBuilderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IFileResultGenerator _excelFileResultGen;

        public ExcelController(IFileResultGenerator excelFileResultGen)
        {
            _excelFileResultGen = excelFileResultGen;
        }

        [HttpGet("Reports/{year}/{provider}")]
        public FileResult GenerateDoc([FromRoute] int year, [FromRoute] IEnumerable<ProviderType> providerTypes)
        {
            var providers = new List<ProviderType> { ProviderType.HotelAlt };

            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Response.ContentType = contentType;
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

            FileResult resultFile = _excelFileResultGen.CreateFile(year, providers, contentType);

            return resultFile;
        }
    }
}
