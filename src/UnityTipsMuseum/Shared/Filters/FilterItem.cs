using UnityTipsMuseum.Infrastructure;
public class FilterItem
{
    public FilterItem(string title, bool selected = false)
    {
        Title = title.ToLowerInvariant();
        Selected = selected;
    }
    public string Title { get; set; }

    public string Color => ColorHelper.GetColor(Title);

    public bool Selected { get; set;}

    public int AffectedCount { get; set; }
}