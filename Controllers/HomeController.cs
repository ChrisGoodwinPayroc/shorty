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
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IUrlService urlService;

        public HomeController(ILogger<HomeController> logger, IUrlService urlService)
        {
            _logger = logger;
            this.urlService = urlService;
        }

        public IActionResult Index(string id)
        {
            var fullUrl = this.urlService.GetFullUrl(id);

            this.urlService.UpdateCount(id);

            var result = new RedirectResult(fullUrl, false);

            return result;
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
