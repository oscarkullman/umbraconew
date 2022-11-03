using Newtonsoft.Json;

namespace umbracoprojekt
{
	public class TriviaAPI
	{
		public static async Task<List<TriviaQuestion>?> GetTriviaQuestion()
		{
			var client = new HttpClient();
			var data = await client.GetFromJsonAsync<List<TriviaQuestion>>("https://jservice.io/api/random?count=50");

			if (data != null)
			{
				return data;
			}

			return null;
		}
	}

	public class TriviaQuestion
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("question")]
		public string? Question { get; set; }

		[JsonProperty("answer")]
		public string? Answer { get; set; }

		[JsonProperty("category")]
		public Category? Category { get; set; }
	}

	public class Category
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("title")]
		public string? Title { get; set; }
	}
}
