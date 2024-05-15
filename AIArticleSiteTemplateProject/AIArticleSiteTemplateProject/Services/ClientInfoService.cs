using AIArticleSiteTemplateProject.Components.Pages.Admin.Diagnostics;
using AIArticleSiteTemplateProject.Data;
using Microsoft.AspNetCore.Identity;

namespace AIArticleSiteTemplateProject.Services
{
    public class ClientInfoService : IClientServices
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClientInfoService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserIPAddress(HttpContext httpContext)
        {
            var ipAddress = httpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = httpContext.Connection.RemoteIpAddress?.ToString();
            }
            return ipAddress ?? "IP Address Not Found";
        }

        public async Task LogUserActivity()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var user = httpContext.User;
            string userId = user.Identity.IsAuthenticated ? _userManager.GetUserId(user) : null;
            var ipAddress = GetUserIPAddress(httpContext);

            var userActivity = new UserActivityLog
            {
                UserId = userId,
                IPAddress = ipAddress,
                Date = DateTime.UtcNow
            };

            _context.UserActivityLog.Add(userActivity);
            await _context.SaveChangesAsync();
        }
    }



}
