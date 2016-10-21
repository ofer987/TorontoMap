using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TorontoMap.Models
{
    public class Status
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("tweet_id")]
        public long TweetId { get; set; }

        [JsonProperty("line_id")]
        public int LineId { get; set; }

        [JsonProperty("line_type")]
        public string LineType { get; set; }

        public string Description { get; set; }

        public string TweetedAt { get; set; }

        public override string ToString()
        {
            return $"LineId {LineId} for type {LineType}";
        }
    }
}
