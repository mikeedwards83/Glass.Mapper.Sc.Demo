using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Glass.Mapper.Sc.Demo.Core.Models;
using Glass.Mapper.Sc.Demo.Core.Models.Parts;
using Glass.Mapper.Sc.Demo.Core.Models.sitecore.templates.Sugnl.Concrete;
using Glass.Mapper.Sc.Demo.Models.Controllers.Comments;
using Sitecore.ContentSearch;
using Sitecore.SecurityModel;
using Sitecore.Shell.Framework.Commands.Media;

namespace Glass.Mapper.Sc.Demo.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ISitecoreContext _context;
        private readonly ISitecoreService _master;

        public CommentsController(
            ISitecoreContext context,
            ISitecoreService master)
        {
            _context = context;
            _master = master;
        }


        [HttpGet]
        public ActionResult Index()
        {
            var model = CreateIndex();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CommentsIndex index)
        {
            CommentsIndex model = null;

            CommentForm form = index.Form;

            if (ModelState.IsValid)
            {
                var currentItem = _context.GetCurrentItem<CommentPage>();
                
                form.Name = "Comment {0}".Formatted(DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss"));
                form.CommentItem = currentItem.Id;
                
                using (new SecurityDisabler())
                {
                    _context.Create(currentItem.CommentStatic, form);
                }

                model = CreateIndex();
                model.Success = true;
            }
            else
            {
                model = CreateIndex(form);
            }

            return View(model);
        }

        private CommentsIndex CreateIndex(CommentForm form = null)
        {
            //TODO: index switching
            var index = ContentSearchManager.GetIndex("sitecore_master_index");
            var currentItem = _context.GetCurrentItem<CommentPage>();

            CommentsIndex commentIndex = new CommentsIndex();
            commentIndex.CommentsStatic = currentItem.CommentStatic;

            using (var context = index.CreateSearchContext())
            {

                commentIndex.Comments = context.GetQueryable<CommentForm>()
                    .Where(x => x.CommentItem == currentItem.Id)
                    .Take(10)
                    .ToList()
                    .Select(x =>
                    {
                        _context.Map(x);
                        return x;
                    });

            }

            commentIndex.Form = new CommentForm();

            return commentIndex;
        }
        
    }
}