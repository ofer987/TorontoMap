using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft;

namespace TorontoMap.Models
{
    public class Status
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("tweet_id")]
        public long TweetId { get; set; }

        [Newtonsoft.Json.JsonProperty("line_id")]
        public int LineId { get; set; }

        [Newtonsoft.Json.JsonProperty("line_type")]
        public string LineType { get; set; }

        public string Description { get; set; }

        public string TweetedAt { get; set; }

        public override string ToString()
        {
            return $"LineId {LineId} for type {LineType}";
        }
    }

    public class Getter
    {
        public string ApiKey { get; }

        public Getter(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        public void ReadFile()
        {
            var path = "./text.txt";
            var stream = new FileStream(path, FileMode.Open);

            var buffer = new byte[100];

            var task = stream.ReadAsync(buffer, 0, buffer.Length, CancellationToken.None);
            task.Wait();

            var sb = new StringBuilder();
            foreach (var ch in buffer)
            {
                sb.Append((char)ch);
            }

            Console.WriteLine(sb.ToString());
            Console.WriteLine(task.IsCompleted);
        }

        public void Lines()
        {
            Console.WriteLine("Directions");
            var client = new HttpClient();
            var url = @"http://ttcnotices.transit.tips/statuses";
            Console.WriteLine($"Trying {url}");
            try
            {
                var task = client.GetAsync(url);
                task.Wait();
                var response = task.Result;
                var contentTask = response.Content.ReadAsStringAsync();
                contentTask.Wait();

                var body = contentTask.Result;
                var statuses = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Status>>(body);

                Console.WriteLine($"Result {response}");
                // Console.WriteLine($"Result {body}");
                Console.WriteLine($"Found {statuses.Count} statuses");
                foreach (var status in statuses)
                {
                    Console.WriteLine(status);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Oops {exception}");
            }
        }
    }
}
