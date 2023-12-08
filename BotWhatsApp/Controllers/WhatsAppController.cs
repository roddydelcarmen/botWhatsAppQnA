using BotWhatsApp.Services.QnAMarkerApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace BotWhatsApp.Controllers
{
    [Route("api/whatsapp")]
    public class WhatsAppController : TwilioController
    {
        private readonly IQnAMarkerApiService _qnAMarkerApiService;
        public WhatsAppController(IQnAMarkerApiService qnAMarkerApiService)
        {
            _qnAMarkerApiService = qnAMarkerApiService;
        }                                                       

        [HttpPost("message")]
        public async Task<TwiMLResult> MessageAsync(SmsRequest input)
        {
            var response = new MessagingResponse();

            string textUser = input.Body; // texto del usuario.
            string textBot = await _qnAMarkerApiService.Execute(textUser);

            response.Message(textBot);
            return TwiML(response);
        }
    }
}
