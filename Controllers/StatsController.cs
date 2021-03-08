using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shorty.Models;

namespace shorty.Controllers
{
    public class StatsController : Controller
    {
        private readonly IUrlService urlService;

        public StatsController(IUrlService urlService)
        {
            this.urlService = urlService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var allUrls = urlService.GetAll();

            return View(allUrls);

        }
    }
}
