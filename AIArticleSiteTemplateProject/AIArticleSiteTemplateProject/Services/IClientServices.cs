namespace AIArticleSiteTemplateProject.Services
{
    public interface IClientServices
    {
        string GetUserIPAddress(HttpContext httpContext);
        Task LogUserActivity();
    }

}
