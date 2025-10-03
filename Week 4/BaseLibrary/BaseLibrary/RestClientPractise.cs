using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace BaseLibrary
{
    internal class RestClientPractise
    {
        static async Task Main(string[] args)
        {
            RestClientOptions options = new RestClientOptions("https://jsonplaceholder.typicode.com/")
            {
                // Configure options as needed
                Timeout = TimeSpan.FromSeconds(10) // Set timeout to 10 
            };

            RestClient client = new RestClient(options);

            RestRequest request = new RestRequest("/posts/1", Method.Get);

            // To add headers
            //request.AddHeader("Accept", "application/json");

            // To add query parameters
            //request.AddParameter("key", "value");

            RestResponse response = await client.GetAsync(request);

            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);


            // For POST request
            RestRequest postRequest = new RestRequest("posts", Method.Post);
            var postData = new
            {
                Title = "My Post Title",
                Body = "This is the body of my post.",
                UserId = 1
            };
            postRequest.AddJsonBody(postData);

            // To add file
            //postRequest.AddFile("fileField", "path/to/file.txt");

            RestResponse postResponse = await client.PostAsync(postRequest);
            Console.WriteLine(postResponse.Content);

        }
    }
}
