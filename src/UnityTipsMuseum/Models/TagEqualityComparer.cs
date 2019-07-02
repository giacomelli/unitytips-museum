using System.Collections.Generic;

namespace UnityTipsMuseum.Models
{
    class TagEqualityComparer : IEqualityComparer<Tag>
    {
        public static readonly TagEqualityComparer Default = new TagEqualityComparer();
        
        public bool Equals(Tag x, Tag y)
        {
            return x.Title == y.Title;
        }

        public int GetHashCode(Tag tag)
        {
            return tag.Title.GetHashCode();
        }
    }
}