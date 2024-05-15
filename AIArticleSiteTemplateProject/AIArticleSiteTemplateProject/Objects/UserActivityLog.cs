namespace AIArticleSiteTemplateProject.Components.Pages.Admin.Diagnostics
{
    public class UserActivityLog
    {
        public int Id { get; set; }
        public string? UserId { get; set; } // Nullable for anonymous users
        public string IPAddress { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow; // Store the UTC time of the activity
    }

}
