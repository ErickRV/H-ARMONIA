using H_API.Services.Interfaces;
using HARMONIA.Domain.DTOs.Telemetria;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace H_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TellemetryController : Controller
    {
        private readonly ITellemetryService tellemetryService;

        public TellemetryController(ITellemetryService tellemetryService)
        {
            this.tellemetryService = tellemetryService;
        }

        [HttpPost("PostHumedalData")]
        public IActionResult PostHumedalData(TellemetryPost dto) {
            string result = tellemetryService.InsertHumedalData(dto);
            if (string.IsNullOrWhiteSpace(result))
                return StatusCode((int)HttpStatusCode.InternalServerError);

            return StatusCode((int)HttpStatusCode.Created, result);
        }
    }
}
