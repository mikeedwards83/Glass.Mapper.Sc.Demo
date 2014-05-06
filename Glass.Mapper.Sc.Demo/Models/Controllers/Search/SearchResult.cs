using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;

namespace Glass.Mapper.Sc.Demo.Models.Controllers.Search
{
    public class SearchResult : SearchResultItem
    {
        public string Url { get; set; }

        [IndexField("ipagetitleslongtitle")]
        public string Title { get; set; }


        
        public string Abstract { get; set; }

       
    }
}
