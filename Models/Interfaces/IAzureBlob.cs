using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GroupWebProject.Models;

namespace GroupWebProject.Models.Interfaces
{
    public interface IAzureBlob
    {
        Task<Document> Upload(IFormFile file);
    }
}
