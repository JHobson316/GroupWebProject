﻿using GroupWebProject.Models.Interfaces;
using GroupWebProject.Models;
using GroupWebProject.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace GroupWebProject.Controllers
{
    public class PictureController : Controller
    {
        IConfiguration Configuration;
        IAzureBlob BlobService;

        public PictureController(IConfiguration config, IAzureBlob blobService)
        {
            Configuration = config;
            BlobService = blobService;

        }
        [Authorize(Policy = "RequireAdmin")]
        public IActionResult Index()
        {
            return Index();
        }
        [Authorize(Policy = "RequireAdmin")]
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {

            Document doc = await BlobService.Upload(file);

            // Upload the file
            return PartialView(doc);
        }
    }
}
