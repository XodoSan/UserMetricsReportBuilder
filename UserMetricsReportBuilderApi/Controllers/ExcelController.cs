using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application;
using System.Collections.Generic;
using System;

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

        [HttpGet("Reports/{year}/{providers}")] 
        public FileResult GenerateDoc([FromRoute] int year, [FromRoute] string providers)
        {
            List<ProviderType> providerTypes = new();
            string[] strings = providers.Split('&');

            for (int i = 0; i < strings.Length; i++)
            {
                providerTypes.Add((ProviderType)Enum.ToObject(typeof(ProviderType), Int32.Parse(strings[i])));
            }

            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Response.ContentType = contentType;
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

            FileResult resultFile = _excelFileResultGen.CreateFile(year, providerTypes, contentType);

            return resultFile;
        }
    }
}
