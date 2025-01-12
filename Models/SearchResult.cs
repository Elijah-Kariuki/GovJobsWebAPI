namespace GovJobsWebAPI.Models
{
    public class SearchResult
    {
        public int SearchResultCount { get; set; }
        public int SearchResultCountAll { get; set; }
        public List<SearchResultItem>? SearchResultItems { get; set; } = new List<SearchResultItem>();
        public UserArea? UserArea { get; set; }

    }
}
