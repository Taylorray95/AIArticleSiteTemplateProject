using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIArticleSiteTemplateProject.Objects
{
    public class TrashedUrl
    {
        public int TrashedUrlId { get; set; }
        public string? TrashedLink { get; set; }
        public DateTime? SysDate { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

    }
}
