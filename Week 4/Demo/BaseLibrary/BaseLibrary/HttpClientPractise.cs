using System.Net.Http.Json;
using System.Web;

namespace BaseLibrary
{
    internal class HttpClientPractise
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();

            string url = "https://jsonplaceholder.typicode.com/posts/1";
            httpClient.BaseAddress = new Uri(url);

            // Property

            Console.WriteLine(httpClient.BaseAddress.ToString());

            //httpClient.DefaultRequestVersion = new Version(2, 0);
            Console.WriteLine(httpClient.DefaultRequestVersion);

            Console.WriteLine(httpClient.Timeout);

            // In bytes
            Console.WriteLine(httpClient.MaxResponseContentBufferSize);



            // Method

            // Cancel all pending requests
            httpClient.CancelPendingRequests();

            // DeleteAsync
            HttpResponseMessage response = await httpClient.DeleteAsync(url);

            // Dispose
            // Implicitly called when using 'using' statement and it call CancelPendingRequests method
            //httpClient.Dispose(); // Dispose the HttpClient instance

            // GetAsync
            response = await httpClient.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            Console.WriteLine($"Status code {response.StatusCode}");

            Console.WriteLine("IsSuccessStatusCode : " + response.IsSuccessStatusCode);

            //Console.WriteLine("Headers : " + response.Headers.ToString());

            Console.WriteLine("Version : " + response.Version.ToString());



            // GetStringAsync
            string result = await httpClient.GetStringAsync(url);
            Console.WriteLine(result);
            // other : GetByteArrayAsync, GetStreamAsync

            Console.WriteLine("\n\n\n\n");
            // PostAsync
            string urlPost = "https://jsonplaceholder.typicode.com/posts";
            var postData = new
            {
                Title = "My Post Title",
                Body = "This is the body of my post.",
                UserId = 1
            };
            string json = System.Text.Json.JsonSerializer.Serialize(postData);
            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // To add headers which will be sent with every request
            //httpClient.DefaultRequestHeaders.Add("Custom-Header", "HeaderValue");

            response = await httpClient.PostAsync(urlPost, content);
            responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            
            response = await httpClient.PostAsJsonAsync(urlPost, postData);
            responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            // other : PostAsXmlAsync

            // To add file
            //MultipartFormDataContent multiPartContent = new ();
            //FileStream file = new FileStream("path/to/file.txt", FileMode.Open, FileAccess.Read);
            //multiPartContent.Add(new StreamContent(file), "fileField", "file.txt");
            //response = await httpClient.PostAsync(urlPost, multiPartContent);

            // similar to PostAsync but used to update existing resources
            // PutAsync, PutAsJsonAsync, PutAsXmlAsync
            // PatchAsync, PatchAsJsonAsync, PatchAsXmlAsync


            // SendAsync
            Console.WriteLine("\n\n\n\n");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

            // To add headers just for this request
            //request.Headers.Add("Custom-Header", "HeaderValue");

            response = await httpClient.SendAsync(request);
            responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);


            // To add query parameters
            Console.WriteLine("\n\n\n\n");
            UriBuilder builder = new UriBuilder("https://jsonplaceholder.typicode.com/posts");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["userId"] = "1";
            builder.Query = query.ToString();
            string urlWithParams = builder.ToString();
            Console.WriteLine(urlWithParams);

        }
    }
}
