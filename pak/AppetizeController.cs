using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RST_WebApi.Controllers
{
    [Route("api/AppetizeApi")]
    [ApiController]
    public class AppetizeController : Controller
    {
        private readonly ILogger<AppetizeController> _logger;

        public AppetizeController(ILogger<AppetizeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}