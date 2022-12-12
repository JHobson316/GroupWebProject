using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using GroupWebProject.Models;
using GroupWebProject.Models.Interfaces;
using GroupWebProject.Models.Services;


namespace GroupWebProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IConfiguration Configuration;
        IAzureBlob BlobService;

        public HomeController(ILogger<HomeController> logger, IConfiguration config, IAzureBlob blobService)
        {
            _logger = logger;
            Configuration = config;
            BlobService = blobService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {

            Document doc = await BlobService.Upload(file);

            // Upload the file
            return View(doc);
        }
    }
}