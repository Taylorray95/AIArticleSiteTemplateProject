using Microsoft.AspNetCore.Identity;

namespace AIArticleSiteTemplateProject.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string? ProfilePhoto { get; set; } = "https://newshog.blob.core.windows.net/profile-photos/default.png";
    }

}
