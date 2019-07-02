using UnityTipsMuseum.Infrastructure;

namespace UnityTipsMuseum.Models
{
    public class Tag 
    {
        public string Title { get; set; }
        public string Color => ColorHelper.GetColor(Title);

        public bool Selected { get; set;}

        public int TipsCount { get; set;}
    }
}