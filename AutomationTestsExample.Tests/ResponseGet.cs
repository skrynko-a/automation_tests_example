using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AutomationTestsExample.Tests
{
    public class ResponseGet
    {
        [JsonProperty("code")] 
        public int? Code { get; set; } 
        
        [JsonProperty("meta")] 
        public Meta Meta { get; set; } 
        
        [JsonProperty("data")] 
        public List<Data> Data { get; set; }
    }
    
    public class Meta
    {
        [JsonProperty("pagination")] 
        public Pagination Pagination { get; set; }
    }
    
    public class Pagination
    {
        [JsonProperty("total")] 
        public int Total { get; set; }

        [JsonProperty("pages")] 
        public int Pages { get; set; }
        
        [JsonProperty("page")] 
        public int Page { get; set; }
        
        [JsonProperty("limit")] 
        public int Limit { get; set; }
    }
    
    public class Data
    {
        [JsonProperty("id")] 
        public int Id { get; set; }

        [JsonProperty("name")] 
        public string Name { get; set; }
        
        [JsonProperty("email")] 
        public string Email { get; set; }
        
        [JsonProperty("gender")] 
        public string Gender { get; set; }
        
        [JsonProperty("status")] 
        public string Status { get; set; }
        
        [JsonProperty("created_at")] 
        public DateTime CreatedAt { get; set; }
        
        [JsonProperty("updated_at")] 
        public DateTime UpdatedAt { get; set; }
    }
}