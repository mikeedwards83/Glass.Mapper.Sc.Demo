using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Demo.Core.Models.sitecore.templates.Common.Static;

namespace Glass.Mapper.Sc.Demo.Core.Models.Parts
{
    [SitecoreType]
    public class CommentPage : GlassBase
    {
        [SitecoreNode(Path = "/sitecore/content/Global/Comments")]
        public virtual Comments CommentStatic { get; set; }

    }
}
