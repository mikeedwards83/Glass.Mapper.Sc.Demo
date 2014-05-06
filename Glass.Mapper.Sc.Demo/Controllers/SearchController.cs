using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Demo.Core.Models;
using Glass.Mapper.Sc.Demo.Core.Models.sitecore.templates.Sugnl.Concrete;
using Glass.Mapper.Sc.Demo.Models.Controllers.Search;
using Glass.Mapper.Sc.Demo.Mvc;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;


namespace Glass.Mapper.Sc.Demo.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISitecoreContext _context;

        public SearchController(ISitecoreContext context)
        {
            _context = context;
        }

        public ActionResult Index(string q, int p = 0)
        {
        //TODO: index switching
            var index = ContentSearchManager.GetIndex("sitecore_master_index");
            var page = _context.GetCurrentItem<Search>();
            var home = _context.GetHomeItem<IGlassBase>();

            int skip = (int)page.SearchResultPerPage * p;

            SearchResults resultPage = new SearchResults();

            if (!string.IsNullOrEmpty(q))
            {

                using (var context = index.CreateSearchContext())
                {
                    var homeId = new ID(home.Id);
                    var results = context.GetQueryable<SearchResult>()
                        .Where(
                            item => item.Content.Contains(q)
                            && item.Language == Sitecore.Context.Language.Name
                            && item.Paths.Contains(homeId))
                        .Skip(skip)
                        // .Take((int) page.SearchResultPerPage)
                        .GetResults();

                    resultPage.Results = results.Hits.Select(x => x.Document).ToList();
                    resultPage.Total = results.TotalSearchResults;
                    resultPage.DisplayNext = resultPage.Total > skip + page.SearchResultPerPage;
                    resultPage.DisplayPrevious = p > 0;
                    resultPage.Start = skip;
                    resultPage.End = skip + resultPage.Results.Count();
                    resultPage.Query = q;
                }
            }

            resultPage.Item = page;
            return View("Search",resultPage);
        }


        public void DoWork()
        {
            var context = new SitecoreContext();

            using (new VersionCountDisabler())
            {
                var current = context.GetCurrentItem<MyModel>();

                //you will need to evaluate the query before you exit the VersionCountDisabler scope
                var results = current.Query.ToList();
            }
            
        }

        public class MyModel
        {
            [SitecoreQuery("./*")]
            public IEnumerable<MyModel> Query { get; set; } 
        }
    }
}