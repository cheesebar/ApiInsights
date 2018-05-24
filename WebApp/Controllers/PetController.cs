using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLog;
using WebApp.Models;
using NLog.Fluent;
using Microsoft.Extensions.Logging;
using Cheers.ApiInsights;

namespace WebApp.Controllers
{
    [Route("pet")]
    public class PetController : Controller
    {
        private readonly ILogger<PetController> _logger;

        public PetController(ILogger<PetController> logger)
        {
            _logger = logger;
        }
        [Route(""),HttpGet]
        public async Task<bool> Get()
        {
            _logger.LogInformation("information");
            _logger.LogTrace("trace");
            _logger.LogDebug("debug");
            _logger.LogCritical("critical");
            _logger.LogWarning("warning");
            _logger.LogError("error");

            return true;
        }
    }


    public class HomeController : Controller
    {
        [NoInsight]
        public async Task<bool> Index()
        {


            return true;
        }
    }
}
