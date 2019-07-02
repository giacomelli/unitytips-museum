public class FilterGroup 
{
    public FilterGroup(string title, FilterItem[] items, bool selected = false)
    {
        Title = title;
        Items = items;
        Selected = selected;
    }
    public string Title { get; set; }

    public bool Selected { get; set;}

    public FilterItem[] Items { get; set; }
}