using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Publishing;

namespace Glass.Mapper.Sc.Demo.Core
{
    
}

namespace Glass.Mapper.Sc.Demo.Core.Models.sitecore.templates.Sugnl.Concrete
{
    public partial class Search
    {
        
        [SitecoreInfo(SitecoreInfoType.Url)]
        public virtual string Url { get; set; }
    }

    public partial class HomePage
    {
        [SitecoreQuery("./../Settings/Quicklinks/*", IsRelative = true)]
        public virtual IEnumerable<QuickLink> QuickLinks { get; set; }

        [SitecoreQuery("./*[@IFeatureFeatured='1']", IsRelative = true)]
        public virtual IEnumerable<Landing> Featured { get;set; } 
    }

    public partial class Comment
    {
        public virtual DateTime Created { get; set; }
    }
}