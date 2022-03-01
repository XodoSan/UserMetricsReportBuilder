using Application.MetricServices;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("GetData/{year}/{providers}")]
        public IReadOnlyList<MetricByDay> GetMetricsByYear([FromRoute] int year, [FromRoute] string providers)
        {
            List<ProviderType> providerTypes = new();
            string[] strings = providers.Split('&');

            for (int i = 0; i < strings.Length; i++)
            {
                providerTypes.Add((ProviderType)Enum.ToObject(typeof(ProviderType), Int32.Parse(strings[i])));
            }

            IReadOnlyList<MetricByDay> resultData = _metricService.GetMetricsByDays(year, providerTypes);

            return resultData;
        }
    }
}
