using Application;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace UserMetricsReportBuilderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricController : ControllerBase
    {
        private readonly IMetricRepository _metricRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MetricController(
            IMetricRepository metricRepository,
            IUnitOfWork unitOfWork)
        {
            _metricRepository = metricRepository;
            _unitOfWork = unitOfWork;
        }
    }
}
