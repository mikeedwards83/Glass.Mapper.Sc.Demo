using System.Collections.Generic;

namespace Glass.Mapper.Sc.Demo.Models.Controllers.Comments
{
    public class CommentsIndex
    {
        public CommentForm Form { get; set; }
        public IEnumerable<CommentForm> Comments { get; set; }
        public bool Success { get; set; }
        public Core.Models.sitecore.templates.Common.Static.Comments CommentsStatic { get; set; }
    }
}
