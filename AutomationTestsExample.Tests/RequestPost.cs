using Newtonsoft.Json;

namespace AutomationTestsExample.Tests
{
    public class RequestPost
    {
        public RequestPost(string title, int userId, string body)
        {
            Title = title;
            UserId = userId;
            Body = body;
        }

        [JsonProperty("title")] 
        public string Title { get; set; } 
        
        [JsonProperty("userId")] 
        public int UserId { get; set; } 
        
        [JsonProperty("body")] 
        public string Body { get; set; }
    }
}