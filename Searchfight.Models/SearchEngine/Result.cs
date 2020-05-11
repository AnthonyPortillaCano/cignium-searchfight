using System;
namespace Searchfight.Models.SearchEngine
{
    public class Result
    {
        public long Number { get; set; } = 0L;
        public string Text { get; set; }
        public TimeSpan Time { get; set; }
    }
}
