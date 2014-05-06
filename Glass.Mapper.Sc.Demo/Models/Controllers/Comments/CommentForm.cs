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
        [DataMember]
        [TypeConverter(typeof(IndexFieldIDValueConverter))]
        [IndexField("_group")]
        [SitecoreId]
        public virtual Guid Id { get; set; }

        [SitecoreInfo(SitecoreInfoType.Name)]
        public virtual string Name { get; set; }

        /// <summary>
        /// The CommentEmail field.
        /// <para></para>
        /// <para>Field Type: Single-Line Text</para>		
        /// <para>Field ID: b96e2942-b55f-4aef-bb5b-dcac931f97cc</para>
        /// <para>Custom Data: </para>
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
        [SitecoreField(ICommentConstants.CommentEmailFieldName)]
        [Required]
        [EmailAddress]
        public virtual string CommentEmail { get; set; }

        /// <summary>
        /// The CommentItem field.
        /// <para></para>
        /// <para>Field Type: Droptree</para>		
        /// <para>Field ID: 991d867a-877f-4058-b513-52b28bd8e67f</para>
        /// <para>Custom Data: </para>
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
        [SitecoreField(ICommentConstants.CommentItemFieldName)]
        public virtual Guid CommentItem { get; set; }

        /// <summary>
        /// The CommentMessage field.
        /// <para></para>
        /// <para>Field Type: Multi-Line Text</para>		
        /// <para>Field ID: fa028db7-c6a7-4ae6-88d9-4adccb188b2b</para>
        /// <para>Custom Data: </para>
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
        [SitecoreField(ICommentConstants.CommentMessageFieldName)]
        [Required]
        public virtual string CommentMessage { get; set; }

        /// <summary>
        /// The CommentName field.
        /// <para></para>
        /// <para>Field Type: Single-Line Text</para>		
        /// <para>Field ID: 853c86ad-1e3f-431d-b6c5-a84bc8708154</para>
        /// <para>Custom Data: </para>
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
        [SitecoreField(ICommentConstants.CommentNameFieldName)]
        [Required]
        public virtual string CommentName { get; set; }


        [SitecoreField("__created", ReadOnly = true)]
        public virtual DateTime Created { get; set; }
    }

}

