using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Glass.Mapper.Sc.Demo.Mvc
{
    public class FormButtonAttribute : ActionMethodSelectorAttribute
    {
        string _name;

        public FormButtonAttribute(string name)
        {
            _name = name;
        }
        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            return !string.IsNullOrEmpty(controllerContext.HttpContext.Request.Form[_name]);
        }
    }
}