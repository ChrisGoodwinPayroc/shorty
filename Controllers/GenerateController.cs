using Microsoft.AspNetCore.Mvc;

namespace shorty.Controllers
{
    public class GenerateController : Controller
    {
        private readonly IUrlService _urlService;

        public GenerateController(IUrlService urlService)
        {
            this._urlService = urlService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index", "");
        }

        [HttpPost]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            string url = Request.Form["txtUrl"];

            var shortUrl = _urlService.GenerateUrl(url);
            
            return View("Index", shortUrl);
        }
    }
}