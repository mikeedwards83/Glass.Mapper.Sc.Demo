using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Configuration.Fluent;
using Glass.Mapper.Sc.Fields;
using Sitecore.Globalization;
using Sitecore.Publishing.PublishingInformation;

namespace Glass.Mapper.Sc.Demo.Core.Fields
{

    /*  
     *  The field mappings for this type must be explicit. This stops them conflicting 
     *  with the fields on the base Image field.
     */

    [SitecoreType]
    public class ExifImage : Image
    {

        //Used to save values back to the target media item
        [SitecoreId]
        public virtual Guid Id { get; set; }

        //Used to save values back to the target media item
        [SitecoreInfo(SitecoreInfoType.Language)]
        public virtual Language Language { get; set; }

        //Used to save values back to the target media item
        [SitecoreInfo(SitecoreInfoType.Version)]
        public virtual int Version { get; set; }


        //Exif values
        [SitecoreField]
        public virtual string Artist { get; set; }
    }
}
