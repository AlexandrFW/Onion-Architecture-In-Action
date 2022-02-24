using Domain.Interfaces.Services;
using Domain.ServiceTools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace M10_Web_API.Controllers
{
    [ApiController]
    [Route("/api/reports")]
    public class ReportsController : Controller
    {
        private readonly IReportApiService _reportService;
        ILogger<ReportsController> _logger;

        public ReportsController(IReportApiService reportService, ILogger<ReportsController> logger)
        {
            _reportService = reportService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult GetReport(ReportFilterCriteria reportCreteria) 
        {
            return Ok(_reportService.GetReport(reportCreteria));
        }
    }
}