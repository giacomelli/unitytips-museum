using System;

namespace UnityTipsMuseum.Models
{
    public class Tip
    {
        public DateTime Date { get; set; }
        public string TweetAuthor { get; set; }
        public string TweetId { get; set; }
        public Tag[] Tags { get; set; }
    }
}
