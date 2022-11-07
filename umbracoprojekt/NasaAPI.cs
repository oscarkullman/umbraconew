using Newtonsoft.Json;

namespace umbracoprojekt
{
    public class NasaAPI
    {
        public static async Task<List<ApiImage>?> GetNasaImages(int numberOfImages)
        {
            var client = new HttpClient();
            var request = await client.GetAsync($"https://api.nasa.gov/planetary/apod?count={numberOfImages}&api_key=GVY8cxDrQrAqumhzBujeWaU2ePMxOoeHD5gOOGes");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ApiImage>>(content);

                return data;
            }

            return null;
        }
    }

    public class ApiImage
    {
        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("explanation")]
        public string? Description { get; set; }

        [JsonProperty("url")]
        public string? ImageUrl { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}
