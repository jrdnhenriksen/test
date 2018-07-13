using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClaimProfilerApi.Helper
{
    public static class JsonConverter
    {
        public static async Task<T> ConvertToObject<T>(this HttpResponseMessage response)
        {
            var data = await response.ReadContentAsync();
            return data.Deserialize<T>();
        }

        private static T Deserialize<T>(this string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        private static async Task<string> ReadContentAsync(this HttpResponseMessage response)
        {
            return await response.Content.ReadAsStringAsync();
        }   
    }
}