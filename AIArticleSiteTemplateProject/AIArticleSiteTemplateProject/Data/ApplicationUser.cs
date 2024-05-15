using Microsoft.AspNetCore.Identity;

namespace AIArticleSiteTemplateProject.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public DateTime LastLogin { get; set; } = DateTime.Now;
        public bool UserHasCommentsVisibleOnProfile { get; set; } = true;

        public string? ProfilPhotoUUID { get; set; }
    }

}
