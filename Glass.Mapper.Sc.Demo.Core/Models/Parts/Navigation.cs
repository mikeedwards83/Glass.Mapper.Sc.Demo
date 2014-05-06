using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Demo.Core.Models.sitecore.templates.Sugnl.Concrete;

namespace Glass.Mapper.Sc.Demo.Core.Models.Parts
{
  //  [SitecoreType(Cachable = true)]
    public class Navigation
    {
        [SitecoreQuery("ancestor-or-self::*[@@templatename='HomePage']", IsRelative = true, IsLazy = false)]
        public HomePage Home { get; set; }

    }
}
