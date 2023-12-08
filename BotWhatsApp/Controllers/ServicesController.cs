using BotWhatsApp.Services.QnAMarkerApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BotWhatsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IQnAMarkerApiService _qnAMarkerApiService;
        public ServicesController(IQnAMarkerApiService qnAMarkerApiService) 
        {
            _qnAMarkerApiService = qnAMarkerApiService;
        }

        [HttpGet("test")]
        public IActionResult Get()
        {
            return Ok("test dev");
        }

        [HttpGet("qnamarker")]
        public async Task<IActionResult> GetQnAMarker(string message)
        {
            var result = await _qnAMarkerApiService.Execute(message);
            return Ok(result);
        }
    }
}
