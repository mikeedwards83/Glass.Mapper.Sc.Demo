using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Glass.Mapper.Sc.Demo.Core.Models.Parts;
using Glass.Mapper.Sc.Demo.Models.Controllers.Comments;
using Glass.Mapper.Sc.Demo.Models.Controllers.CommentsSearch;
using Sitecore.ContentSearch;

namespace Glass.Mapper.Sc.Demo.Controllers
{
    public class CommentsSearchController : Controller
    {
        private readonly ISitecoreContext _context;

        public CommentsSearchController(ISitecoreContext context)
        {
            _context = context;
        }


        public ActionResult Index(string name)
        {
            var index = ContentSearchManager.GetIndex("sitecore_master_index");

            using (var context = index.CreateSearchContext())
            {

                var results = context.GetQueryable<CommentResult>()
                    .Where(x => x.CommentName.Contains(name) || x.CommentMessage.Contains(name))
                    .Take(10)
                    .ToList()
                    .Select(x =>
                    {
                        _context.Map(x);
                        return x;
                    });

                return Json(results, JsonRequestBehavior.AllowGet);

            }


        }
    }
}