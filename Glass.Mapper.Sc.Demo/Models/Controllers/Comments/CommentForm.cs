using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Demo.Core.Models.sitecore.templates.Sugnl.Concrete;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Converters;
using Sitecore.ContentSearch.SearchTypes;

namespace Glass.Mapper.Sc.Demo.Models.Controllers.Comments
{
    [SitecoreType(TemplateId = ICommentConstants.TemplateIdString)]
    public class CommentForm 
    {
        [TypeConverter(typeof(IndexFieldIDValueConverter))]
        [IndexField("_group")]
        [SitecoreId]
        public virtual Guid Id { get; set; }

        [SitecoreInfo(SitecoreInfoType.Name)]
        public virtual string Name { get; set; }

        [SitecoreField(ICommentConstants.CommentEmailFieldName)]
        [Required]
        [EmailAddress]
        public virtual string CommentEmail { get; set; }
        
        [SitecoreField(ICommentConstants.CommentItemFieldName)]
        public virtual Guid CommentItem { get; set; }
        
        [SitecoreField(ICommentConstants.CommentMessageFieldName)]
        [Required]
        public virtual string CommentMessage { get; set; }
        
        [SitecoreField(ICommentConstants.CommentNameFieldName)]
        [Required]
        public virtual string CommentName { get; set; }

        [SitecoreField("__created", ReadOnly = true)]
        public virtual DateTime Created { get; set; }
    }

}

