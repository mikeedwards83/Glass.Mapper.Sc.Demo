using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Shell.Framework.Commands;

namespace Glass.Mapper.Sc.Demo.Models.Parts
{
    [SitecoreType( Cachable = true)]
    public class SiteMap
    {
        [SitecoreQuery("/sitecore/content")]
        public virtual SiteMapItem Root { get; set; }
    }

    [SitecoreType(AutoMap = true, Cachable = true)]
    public class SiteMapItem
    {
        public virtual string Url { get; set; }
        public virtual string Name { get; set; }

        public virtual IEnumerable<SiteMapItem> Children { get; set; } 

    }
}