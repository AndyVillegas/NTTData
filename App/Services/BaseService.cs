using App.Common;
using App.Exceptions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class BaseService
    {
        private readonly IConfiguration _config;
        private const string API_URL = "ApiURL";
        private static HttpClient client = new HttpClient();
        public BaseService(IConfiguration configuration)
        {
            _config = configuration;
        }
        public async Task<T> GetAsync<T>(string url)
        {
            var responseTask = client.GetAsync($"{_config.GetValue<string>(API_URL)}{url}");
            var result = await responseTask;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<T>();
                return await readTask;
            }
            throw new System.Exception();
        }
        public async Task<T> PostAsync<T>(string url, T content)
        {
            var responseTask = client.PostAsJsonAsync($"{_config.GetValue<string>(API_URL)}{url}", content);
            var result = await responseTask;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<T>();
                return await readTask;
            }
            if(result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var response = await result.Content.ReadAsAsync<ErrorResponse>();
                throw new ValidationException(response.Message, response.Code);
            }
            throw new System.Exception();
        }
        public async Task<T> PutAsync<T>(string url, T content)
        {
            var responseTask = client.PutAsJsonAsync($"{_config.GetValue<string>(API_URL)}{url}", content);
            var result = await responseTask;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<T>();
                return await readTask;
            }
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var response = await result.Content.ReadAsAsync<dynamic>();
                throw new ValidationException(response.message);
            }
            throw new System.Exception();
        }
        public async Task DeleteAsync(string url)
        {
            var responseTask = client.DeleteAsync($"{_config.GetValue<string>(API_URL)}{url}");
            var result = await responseTask;
            if (!result.IsSuccessStatusCode)
            {
                throw new System.Exception();
            }
        }
    }
}
