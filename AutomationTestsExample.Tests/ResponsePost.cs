using Newtonsoft.Json;

namespace AutomationTestsExample.Tests
{
    public class ResponsePost
    {
        [JsonProperty("id")] 
        public int? Id { get; set; } 
        
        [JsonProperty("title")] 
        public string Title { get; set; } 
        
        [JsonProperty("userId")] 
        public int UserId { get; set; } 
        
        [JsonProperty("body")] 
        public string Body { get; set; }
    }
}