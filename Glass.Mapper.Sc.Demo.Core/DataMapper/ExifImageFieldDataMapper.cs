using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glass.Mapper.Configuration;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.DataMappers;
using Glass.Mapper.Sc.Demo.Core.Fields;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace Glass.Mapper.Sc.Demo.Core.DataHandlers
{
    public class ExifImageFieldDataMapper : Glass.Mapper.Sc.DataMappers.SitecoreFieldImageMapper
    {
        public override object GetField(Field field, SitecoreFieldConfiguration config,
            SitecoreDataMappingContext context)
        {
            ImageField field1 = new ImageField(field);

            ExifImage img;

            // if there is a target media item then we use Glass to create a concrete version 
            // of that using it's standard field mappings. Otherwise we just use a blank copy.
            if (field1.MediaItem == null)
            {
                img = new ExifImage();
            }
            else
            {
                img = context.Service.CreateType<ExifImage>(field1.MediaItem);
            }

            //with the new populated class we then populate the image with specific field values.
            SitecoreFieldImageMapper.MapToImage(img, field1);
            
            return (object) img;
        }

        public override void SetField(Field field, object value, SitecoreFieldConfiguration config, SitecoreDataMappingContext context)
        {
            
            ExifImage image = value as ExifImage;

            Item obj = field.Item;
            if (field == null)
                return;

            //save the values back to the field first
            SitecoreFieldImageMapper.MapToField(new ImageField(field), image, obj);

            //then save any values that were edited on the target media item
            context.Service.Save(image);
            
            base.SetField(field, value, config, context);
        }

        public override bool CanHandle(AbstractPropertyConfiguration configuration, Context context)
        {
            return configuration is SitecoreFieldConfiguration &&
                   configuration.PropertyInfo.PropertyType == typeof (ExifImage);
        }
    }
}
