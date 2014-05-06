using System.Collections.Generic;

namespace Glass.Mapper.Sc.Demo.Models.Controllers.Search
{
    public class SearchResults
    {
        public SearchResults()
        {
            Results = new SearchResult[0];
        }
        public IEnumerable<SearchResult> Results { get; set; }
        public Core.Models.sitecore.templates.Sugnl.Concrete.Search Item { get; set; }

        public int Total { get; set; }
        public bool DisplayNext { get; set; }
        public bool DisplayPrevious { get; set; }

        public int Start { get; set; }

        public int End { get; set; }

        public string Query { get; set; }
    }
}
