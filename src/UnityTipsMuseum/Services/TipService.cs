using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using UnityTipsMuseum.Infrastructure;
using UnityTipsMuseum.Models;

namespace UnityTipsMuseum.Services
{
    public class TipService 
    {
        Tip[] _tips;
        Tag[] _tags;
        string[] _authors;
        DateTime[] _dates;
        HttpClient _http;
        LogService _log;

        public TipService(HttpClient http, LogService log)
        {
            _http = http;
            _log = log;
        }

        public async Task<PagedResult<Tip>> GetTipsAsync(TipFilter filter)
        {
            await LoadDataAsync();

            IEnumerable<Tip> tipsFiltered = _tips;

            if(filter.Tags.Any())
                tipsFiltered = tipsFiltered.Where(tip => !filter.Tags.Any() || filter.Tags.All(filterTag => tip.Tags.Any(tipTag => tipTag.Title == filterTag)));

            if (filter.Date.HasValue)
                tipsFiltered = tipsFiltered.Where(tip => tip.Date == filter.Date.Value);

            if (!string.IsNullOrEmpty(filter.TweetAuthor))
                tipsFiltered = tipsFiltered.Where(tip => tip.TweetAuthor == filter.TweetAuthor);

            return new PagedResult<Tip>(tipsFiltered.ToArray(), filter.Paging);
        }

        public async Task<Tag[]> GetTagsAsync()
        {
            await LoadDataAsync();
            return _tags;
        }

        public async Task<DateTime[]> GetDatesAsync()
        {
            await LoadDataAsync();
            return _dates;
        }

        public async Task<string[]> GetAuthorsAsync()
        {
            await LoadDataAsync();
            return _authors;
        }
        private async Task LoadDataAsync()
        {
            if (_tips == null)
            {
                await _log.Debug("Loading tips...");
                _tips = await _http.GetJsonAsync<Tip[]>("data/tips.json");
                await _log.Debug($"{_tips.Length} tips found.");

                _tags = _tips.GetUniqueTags();
                await _log.Debug($"{_tags.Length} tags found.");

                // Keep the tips with same tags references and count tag tips.
                foreach(var tip in _tips)
                {
                    var tags = _tags.Where(tag => tip.Tags.Any(tipTag => tipTag.Title == tag.Title)).ToArray();

                    foreach(var t in tags)
                    {
                        t.TipsCount++;
                    }

                    tip.Tags = tags;
                }

                _authors = _tips.Select(x => x.TweetAuthor.ToLowerInvariant()).Distinct().OrderBy(x => x).ToArray();
                _dates = _tips.Select(x => x.Date).Distinct().OrderByDescending(x => x).ToArray();
            }
        }
    }
}

public class TipFilter
{
   public IList<string> Tags { get; set; }
   public Paging Paging { get; set; } = new Paging(1, 9);

   public string TweetAuthor { get; set; }

   public DateTime? Date { get; set; }

   public void Reset()
   {
       Tags.Clear();
       Paging = new Paging(1, 9);
       TweetAuthor = null;
       Date = null;
   }
}