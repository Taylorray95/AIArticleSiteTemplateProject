using System.ComponentModel.DataAnnotations.Schema;

namespace AIArticleSiteTemplateProject.Objects
{
    public class ArticleParsed
    {
        public int ArticleParsedId { get; set; }
        public string? SourceUrl { get; set; }
        public string? SourceTitle { get; set; }
        public DateTime ParsedDate { get; set; } = DateTime.Now;
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post? Post { get; set; }
    }
}
