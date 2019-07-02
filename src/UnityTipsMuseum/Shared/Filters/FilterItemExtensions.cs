using System;
using System.Collections.Generic;
using System.Linq;
using UnityTipsMuseum.Models;

namespace UnityTipsMuseum.Shared.Filters
{
    public static class FilterItemExtensions
    {
        public static FilterItem[] ToFilterItems(this IEnumerable<Tag> tags)
        {
            return tags
                    .Select(x => new FilterItem(x.Title) { AffectedCount = x.TipsCount } )
                    .ToArray();
        }

        public static FilterItem[] ToFilterItems(this IEnumerable<string> texts)
        {
            return texts
                    .Select(x => new FilterItem(x))
                    .ToArray();
        }

        public static FilterItem[] ToFilterItems(this IEnumerable<DateTime> dates)
        {
            return dates
                    .Select(x => new FilterItem(x.ToShortDateString()))
                    .ToArray();
        }
    }
}