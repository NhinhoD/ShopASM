using ShopShareLibrary.Contracts;
using ShopShareLibrary.Models;
using ShopShareLibrary.Reponses;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ShopClient.Services
{
    public class ClientServices(HttpClient httpClient) : IProduct
    {
        private const string BaseUrl = "api/product";
        private static StringContent GenerateStringContent(string serialiazedOjb) => new(serialiazedOjb , System.Text.Encoding.UTF8, "application/json");
        private static string SerializeObject(object obj) => JsonSerializer.Serialize(obj, JsonOptions());
        private static T DeserializeJsonString<T>(string json) => JsonSerializer.Deserialize<T>(json, JsonOptions())!;
        private static IList<T> DeserializeJsonStringList<T>(string json) => JsonSerializer.Deserialize<IList<T>>(json, JsonOptions())!;
        private static JsonSerializerOptions JsonOptions()
        {
            return new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip
            };
        }


        public async Task<ServiceRepose> AddProduct(Product model)
        {
            var response = await httpClient.PostAsync(BaseUrl, GenerateStringContent(SerializeObject(model)));
            if (!response.IsSuccessStatusCode)
            {
                return new ServiceRepose("Xảy ra lỗi. Vui lòng thử lại sau!", false);
            }
            var apiResponse = await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<ServiceRepose>(apiResponse);
        }

        public async Task<List<Product>> GetAllProduct(bool featuredProducts)
        {
            var response = await httpClient.GetAsync($"{BaseUrl}?featured={featuredProducts}");
            if (!response.IsSuccessStatusCode)
            {
                return null!;
            }
            var result = await response.Content.ReadAsStringAsync();
            return [.. DeserializeJsonStringList<Product>(result)];
        }
    }
}
