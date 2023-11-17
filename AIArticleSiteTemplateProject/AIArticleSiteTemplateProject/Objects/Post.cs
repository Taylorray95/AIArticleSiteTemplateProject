namespace AIArticleSiteTemplateProject.Objects
{
    public class Post
    {
        public int PostId { get; set; }
        public string? PostShortTitle { get; set; }
        public string? PostTitle { get; set; }
        public string? PostBody { get; set; }
        public int PostCategoryId { get; set; }
        public Category? Category { get; set; }
        public DateTime? PostSysDate { get; set; } = DateTime.Now;
        public DateTime? PostLastUpdated { get; set; } = DateTime.Now;
        public string? PathToHeaderImage { get; set; }
        public string? PathToBodyImage { get; set; }
        public int TotalComments { get; set; } = 0;
        public int PageViews { get; set; } = 0;
        public int StatusId { get; set; } = 1;
        public string PathToImage3 { get; set; } = "";
        public string PathToImage4 { get; set; } = "";
        public string Article_Parsed_Url { get; set; } = "";


    }
}
