using System.Collections.Generic;
using System.Linq;

namespace UnityTipsMuseum.Models
{
    public static class TipExtensions
    {
        public static Tag[] GetUniqueTags(this IEnumerable<Tip> tips)
        {
            return tips
                .SelectMany(x => x.Tags)
                .Distinct(TagEqualityComparer.Default)
                .OrderBy(x => x.Title)
                .ToArray();
        }
    }
}