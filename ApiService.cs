using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows;

namespace ExamModule4
{

    public class ApiService
    {
        private readonly HttpClient _client;

        public ApiService()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetDataAsync()
        {
            string url = "http://localhost:4444/TransferSimulator/fullName";

            try
            {
                string json = await _client.GetStringAsync(url);

                var result = JsonConvert.DeserializeObject<JsonResponse>(json);
                return result.Value;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Ошибка запроса: {ex.Message}");
                return null;
            }
        }
    }

}
