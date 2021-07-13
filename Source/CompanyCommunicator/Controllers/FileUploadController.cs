namespace Microsoft.Teams.Apps.CompanyCommunicator.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Controller for the draft notification data.
    /// </summary>
    [Route("api/fileupload")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        /// <summary>
        /// Preview draft notification.
        /// </summary>
        /// <param name="file">save file.</param>
        /// <returns>
        /// It returns 400 bad request error if the incoming parameter, draftNotificationPreviewRequest, is invalid.
        /// It returns 404 not found error if the DraftNotificationId or TeamsTeamId (contained in draftNotificationPreviewRequest) is not found in the table storage.
        /// It returns 500 internal error if this method throws an unhandled exception.
        /// It returns 429 too many requests error if the preview request is throttled by the bot service.
        /// It returns 200 OK if the method is executed successfully.</returns>
        [HttpPost]
        [Route("savepdffile")]
        public async Task<ActionResult> SaveProfilePicAsync(IFormFile file)
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
                var storageConnectionString = configuration.GetSection("StorageAccountConnectionString").Value.ToString();

                if (CloudStorageAccount.TryParse(storageConnectionString, out CloudStorageAccount storageAccount))
                {
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                    CloudBlobContainer container = blobClient.GetContainerReference("pdffiles");

                    await container.CreateIfNotExistsAsync(BlobContainerPublicAccessType.Blob, default, default);
                    var picBlob = container.GetBlockBlobReference(file.FileName);

                    await picBlob.UploadFromStreamAsync(file.OpenReadStream());

                    return this.Ok(picBlob.Uri);
                }

                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}