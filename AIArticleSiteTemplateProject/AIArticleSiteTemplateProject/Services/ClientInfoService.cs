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

            if (user.Identity.IsAuthenticated)
            {
                string userId = _userManager.GetUserId(user);

                if (await _userManager.IsInRoleAsync(await _userManager.FindByIdAsync(userId), "SuperAdmin") ||
                    await _userManager.IsInRoleAsync(await _userManager.FindByIdAsync(userId), "Admin"))
                {
                    return;
                }

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
            else
            {
                var ipAddress = GetUserIPAddress(httpContext);

                var userActivity = new UserActivityLog
                {
                    UserId = null,
                    IPAddress = ipAddress,
                    Date = DateTime.UtcNow
                };

                _context.UserActivityLog.Add(userActivity);
                await _context.SaveChangesAsync();
            }
        }

    }



}
