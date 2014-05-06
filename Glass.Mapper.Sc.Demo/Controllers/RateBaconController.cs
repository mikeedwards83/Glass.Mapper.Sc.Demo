using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Glass.Mapper.Sc.Demo.Core.Models.sitecore.templates.Sugnl.Concrete;
using Glass.Mapper.Sc.Demo.Models.Controllers.RateBacon;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Shell.Framework.Commands.Masters;

namespace Glass.Mapper.Sc.Demo.Controllers
{
    public class RateBaconController : GlassController
    {
        private readonly ISitecoreService _service;

        public RateBaconController(
            ISitecoreContext context,
            ISitecoreService service

            ):base(context, new GlassHtml(context))
        {
            _service = service;
        }


        [HttpGet]
        public ActionResult Index()
        {
            var model = new RateBaconIndex();
            var page = GetControllerItem<RateBacon>();

            model.Item = page;


            return View(model);
        }

        [HttpGet]
        public JsonResult Rate(Guid itemId, int ratingNumber, float rating)
        {

            var page = SitecoreContext.GetItem<RateBacon>(itemId);

            float newRating = 0;
            float count = 0;

            switch (ratingNumber)
            {
                case 1:
                    page.RateBaconRate1 = CalculateRating(page.RateBaconRate1, page.RateBaconCount1, rating);
                    page.RateBaconCount1++;
                    count = page.RateBaconCount1;

                    newRating = page.RateBaconRate1;
                    break;
                    case 2:
                    page.RateBaconRate2 = CalculateRating(page.RateBaconRate2, page.RateBaconCount2, rating);
                    page.RateBaconCount2++;
                    count = page.RateBaconCount2;
                    newRating = page.RateBaconRate2;
                    break;
                      case 3:
                    page.RateBaconRate3 = CalculateRating(page.RateBaconRate3, page.RateBaconCount3, rating);
                    page.RateBaconCount3++;
                    count = page.RateBaconCount3;
                    newRating = page.RateBaconRate3;;
                    break;
                      case 4:
                    page.RateBaconRate4 = CalculateRating(page.RateBaconRate4, page.RateBaconCount4, rating);
                     page.RateBaconCount4++;
                    count = page.RateBaconCount4;
                    newRating = page.RateBaconRate4;;
                    break;
            }

            _service.Save(page);

            return Json(new {rating = newRating, count = count}, JsonRequestBehavior.AllowGet);
        }

        private float CalculateRating(float previousRating, float previousCount, float currentRating)
        {
            if (previousCount == 0)
                return currentRating;

            return previousRating + ((currentRating - previousRating) / (previousCount++));

        }


    }
}