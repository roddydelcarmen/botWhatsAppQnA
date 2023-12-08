using System.Threading.Tasks;

namespace BotWhatsApp.Services.QnAMarkerApi
{
    public interface IQnAMarkerApiService
    {
        Task<string> Execute(string text);
    }
}
