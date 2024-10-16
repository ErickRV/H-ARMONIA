using H_API.Services.Interfaces;
using HARMONIA.Domain.DTOs.Telemetria;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace H_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TellemetryController : Controller
    {
        private readonly ITellemetryService tellemetryService;
        private readonly string NeemKey;
        private readonly string AuthHeaderName;

        public TellemetryController(ITellemetryService tellemetryService, IConfiguration config)
        {
            this.tellemetryService = tellemetryService;
            NeemKey = config.GetValue<string>("NeemToken");
            AuthHeaderName = config.GetValue<string>("HeaderName");
        }

        [HttpPost("PostHumedalData")]
        public IActionResult PostHumedalData(TellemetryPost dto) {

            if (!Request.Headers.Any(x => x.Key == AuthHeaderName))
                return Forbid();

            var auth = Request.Headers.First(x => x.Key == AuthHeaderName);
            if(auth.Value != NeemKey)
                return Forbid();

            string result = tellemetryService.InsertHumedalData(dto);
            if (string.IsNullOrWhiteSpace(result))
                return StatusCode((int)HttpStatusCode.InternalServerError);

            return StatusCode((int)HttpStatusCode.Created, result);
        }
    }
}
