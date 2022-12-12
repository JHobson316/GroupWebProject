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
using GroupWebProject.Models.Interfaces;

namespace GroupWebProject.Models.Services
{
    class AzureBlobService : IAzureBlob
    {
        private IConfiguration Configuration { get; }

        public AzureBlobService(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task<Document> Upload(IFormFile file)
        {
            BlobContainerClient container = new BlobContainerClient(Configuration.GetConnectionString("AzureBlob"), "images");
            await container.CreateIfNotExistsAsync();
            container.SetAccessPolicy(PublicAccessType.BlobContainer, null, null, default);

            BlobClient blob = container.GetBlobClient(file.FileName);
            using var stream = file.OpenReadStream();

            BlobUploadOptions options = new BlobUploadOptions()
            {
                HttpHeaders = new BlobHttpHeaders()
                {
                    ContentType = file.ContentType
                }
            };
            if (!blob.Exists())
            {
                await blob.UploadAsync(stream, options);
            }

            Document document = new Document()
            {
                Name = file.FileName,
                Size = file.Length,
                Type = file.ContentType,
                Url = blob.Uri.ToString(),
            };

            return document;
        }
    }
}
