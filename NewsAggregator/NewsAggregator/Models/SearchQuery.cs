﻿namespace NewsAggregator.Models
{
    public class SearchQuery
    {
        public int Id { get; set; }
        public int Source { get; set; }
        public string Pattern { get; set; }
    }
}