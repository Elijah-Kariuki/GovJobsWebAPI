namespace GovJobsWebAPI.Models
{
    public class Job
    {
        public string LanguageCode { get; set; }
        public SearchParameters SearchParameters { get; set; }
        public SearchResult SearchResult { get; set; }

        public Job() { }

        public Job(SearchResult searchResult)
        {
            LanguageCode = "EN";
            SearchParameters = new SearchParameters();
            SearchResult = searchResult;
        }
    }
}
