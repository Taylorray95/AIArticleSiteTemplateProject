using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace AIArticleSiteTemplateProject.Data
{
    public class DynamicModelCacheKeyFactory : IModelCacheKeyFactory
    {

        public object Create(DbContext context, bool designTime)
        {
            if (context is ApplicationDbContext dbContext)
            {
                var appName = dbContext.GetService<IConfiguration>().GetValue<string>("ApplicationName") ?? "DefaultApp";
                return (context.GetType(), appName, designTime);
            }

            return (context.GetType(), designTime);
        }

    }
}
