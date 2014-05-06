using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;

namespace Glass.Mapper.Sc.Demo.Controllers
{
    public class TempController :GlassController
    {
        public override ActionResult Index()
        {
            return Json(new {world="hi"}, JsonRequestBehavior.AllowGet);
            
        }
    }
}