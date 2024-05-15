using System.ComponentModel.DataAnnotations.Schema;

namespace AIArticleSiteTemplateProject.Objects
{
    public class Post
    {
        public int PostId { get; set; }
        public string? PostShortTitle { get; set; }
        public string? PostTitle { get; set; }
        public string? PostBody { get; set; }
        public DateTime? PostSysDate { get; set; } = DateTime.Now;
        public DateTime? PostLastUpdated { get; set; } = DateTime.Now;
        public string? HeaderImage { get; set; }
        //public bool? HeaderImageIsLinkFlag { get; set; } = true;
        //public string? HeaderImageIDIfNotLink { get; set; }
        public string? BodyImage { get; set; }
        //public bool? BodyImageIsLinkFlag { get; set; } = true;
        //public string? BodyImageIDIfNotLink { get; set; }
        public int? TotalComments { get; set; } = 0;
        public int? PageViews { get; set; } = 0;
        public string? Image3 { get; set; } = "";
        //public bool? Image3IsLinkFlag { get; set; } = true;
        //public string? Image3ImageIDIfNotLink { get; set; }
        public string? Image4 { get; set; } = "";
        //public bool? Image4IsLinkFlag { get; set; } = true;
        //public string? Image4ImageIDIfNotLink { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public PostStatus? PostStatus { get; set; }
    }
}
