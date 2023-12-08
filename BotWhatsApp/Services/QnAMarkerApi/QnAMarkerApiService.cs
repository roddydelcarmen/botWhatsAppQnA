using Azure;
using Azure.AI.Language.QuestionAnswering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Threading.Tasks;

namespace BotWhatsApp.Services.QnAMarkerApi
{
    public class QnAMarkerApiService: IQnAMarkerApiService
    {
        public async Task<string> Execute(string text)
        {
            try
            {
                var supcriptionKey = "b0db7a64079a4f4d81e9ad8c84fe1fe0";
                var endPoint = "https://botwhatsapplanguage.cognitiveservices.azure.com";
                var projectName = "botwhatsapp";
                var deploymentName = "production";

                AzureKeyCredential credential = new AzureKeyCredential(supcriptionKey);
                Uri endpointUri = new Uri(endPoint);
                QuestionAnsweringClient client = new QuestionAnsweringClient(endpointUri, credential);
                QuestionAnsweringProject project = new QuestionAnsweringProject(projectName, deploymentName);
                var response = await client.GetAnswersAsync(text, project, new AnswersOptions { Size = 3 });

                if (response != null && response.Value.Answers.Count > 0)
                {
                    var answerBot = response.Value.Answers[0].Answer;
                    var score = response.Value.Answers[0].Confidence;

                    if (answerBot != null)
                    {
                        if (score == 0 )
                        {
                            return "Lo siento no puedo entenderte.";
                        }
                        else
                        {
                            return answerBot;
                        }
                    }

                }
                return "Lo siento algo salio mal, intentalo mas tarde.";
            }
            catch (Exception)
            {
                return "Lo siento algo salio mal, intentalo mas tarde.";
                throw;
            }
        }
    }
}
