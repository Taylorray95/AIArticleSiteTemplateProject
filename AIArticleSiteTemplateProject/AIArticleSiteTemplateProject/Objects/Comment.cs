using System.ComponentModel.DataAnnotations.Schema;

namespace AIArticleSiteTemplateProject.Objects
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post? Post { get; set; }
        public int? ParentCommentId { get; set; }
        [ForeignKey("ParentCommentId")]
        public Comment? ParentComment { get; set; }
        public string? CommentBody { get; set; }
        public DateTime CommentSysDate { get; set; } = DateTime.Now;
        public DateTime CommentLastUpdated { get; set; } = DateTime.Now;
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public ICollection<Comment>? Replies { get; set; } 
    }
}
