using System.Net.Http.Headers;

namespace WordPredictorMinimalApi.Clients
{
    public class LingappsClient
    {
        static HttpClient httpClient = new HttpClient();
        static string url = "https://services.lingapps.dk/misc/getPredictions";
        static string apiKey = "";
        static string locale = "en-GB";
        public async Task<string> Get(string? textInput)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            var response = await httpClient.GetAsync($"{url}?locale={locale}&text={textInput}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
