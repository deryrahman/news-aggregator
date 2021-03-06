﻿namespace NewsAggregator.Search
{
    public abstract class Searcher
    {
        protected string Pattern;

        public Searcher(string pattern)
        {
            SetPattern(pattern);
        }

        public abstract void SetPattern(string pattern);
        public abstract int CheckMatch(string text);
    }
}