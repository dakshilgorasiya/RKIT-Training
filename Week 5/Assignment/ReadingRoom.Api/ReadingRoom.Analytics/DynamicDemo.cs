using Newtonsoft.Json;

namespace ReadingRoom.Analytics
{
    class QuoteData
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }
        public string AuthorSlug { get; set; }
        public int Length { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
    }

    class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public QuoteData Data { get; set; }
    }
    public static class DynamicDemo
    {
        public static async Task PerformDemo()
        {
            string url = "https://api.freeapi.app/api/v1/public/quotes/quote/random";

            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserialize to dynamic object
                dynamic quoteData = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
                
                // Access properties dynamically
                string quote = quoteData.data.content;
                string tags = string.Join(", ", quoteData.data.tags);

                Console.WriteLine($"[Dynamic Typed] Quote: {quote}");
                Console.WriteLine($"[Dynamic Typed] Tags: {tags}\n\n");
            }
            else
            {
                Console.WriteLine("Error fetching data from API.");
            }

            response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {


                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserialize to strongly typed object
                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);

                // Access properties
                string? quote = apiResponse.Data.Content;
                string? tags = string.Join(", ", apiResponse.Data.Tags);

                Console.WriteLine($"[Strongly Typed] Quote: {quote}");
                Console.WriteLine($"[Strongly Typed] Tags: {tags}");
            }
        }
    }
}
