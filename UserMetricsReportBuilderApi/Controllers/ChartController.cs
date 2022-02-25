using Application.MetricServices;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UserMetricsReportBuilderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly IMetricService _metricService;

        public ChartController(IMetricService metricService)
        {
            _metricService = metricService;
        }

        [HttpGet("GetData/{year}/{provider}")]
        public IReadOnlyList<MetricByDay> GetMetricsByYear([FromRoute] int year, [FromRoute] IEnumerable<ProviderType> providerTypes)
        {
            var providers = new List<ProviderType> { ProviderType.HotelAlt };
            IReadOnlyList<MetricByDay> resultData = _metricService.GetMetricsByDay(year, providers);

            return resultData;
        }
    }
}
