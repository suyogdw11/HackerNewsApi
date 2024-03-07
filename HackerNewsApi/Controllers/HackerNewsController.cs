using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using HackerNewsApi.Services;
using HackerNewsApi.Services.Api;
using HackerNewsApi.Model;
using Microsoft.AspNetCore.Http;

namespace HackerNewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HackerNewsController : ControllerBase
    {
        private readonly ILogger<HackerNewsController> _logger;
        private IHackerNewsService _hackerNewsService;
        public HackerNewsController(ILogger<HackerNewsController> logger, IHackerNewsService hackerNewsService)
        {
            _hackerNewsService = hackerNewsService;
            _logger = logger;
        }


        [HttpGet]
        [Route("/hackernews")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(typeof(IEnumerable<OutputStory>))]
        public async Task<IEnumerable<OutputStory>> Get()
        {
            bool disableCache = false;
            bool.TryParse(Request.Headers["DisableCache"], out disableCache);

            return await _hackerNewsService.GetBestOrderedStories(disableCache);
        }


        /// <summary>
        ///     Clean the news cache
        /// </summary>
        /// <remarks>
        ///     Sample request:
        ///     GET /clean
        /// </remarks>        
        /// <response code="200">Cache cleaned successfully</response>
        /// <response code="500">Server internal error</response>
        [HttpGet]
        [Route("/clean")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CleanCache()
        {
            _hackerNewsService.CleanCache();
            return Ok();
        }
    }
}
