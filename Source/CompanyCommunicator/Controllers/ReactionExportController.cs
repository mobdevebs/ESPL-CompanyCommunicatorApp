﻿
namespace Microsoft.Teams.Apps.CompanyCommunicator.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Teams.Apps.CompanyCommunicator.Helpers;

    /// <summary>
    /// Controller for the survey export data.
    /// </summary>
    [Route("api/reactionexport")]
    [ApiController]
    public class ReactionExportController : ControllerBase
    {
        /// <summary>
        /// Get a sent notification by Id.
        /// </summary>
        /// <param name="id">Id of the requested sent notification.</param>
        /// <returns>Required sent notification.</returns>
        [HttpPost]
        [Route("exportdata")]
        public async Task<IActionResult> GetReactionExport(string id)
        {
            CloudStorageHelper cloudStorageHelper = new CloudStorageHelper();
            var result = await cloudStorageHelper.GetReactionList(id);
            return this.Ok(result);
        }
    }
}