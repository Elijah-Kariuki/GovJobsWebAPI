namespace GovJobsWebAPI.Models
{
    public class SearchResultItem
    {
        public string? MatchedObjectId { get; set; }
        public MatchedObjectDescriptor? MatchedObjectDescriptor { get; set; }
        public float RelevanceRank { get; set; }
        
    }
}
