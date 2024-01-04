using AIArticleSiteTemplateProject.Objects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AIArticleSiteTemplateProject.Data
{
    //public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        private readonly IConfiguration _configuration;

        public DbSet<PostStatus> PostStatuses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ArticleParsed> ArticleParsed { get; set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Retrieve the application name from appsettings.json
            string tablePrefix = _configuration["ApplicationSettings:ApplicationName"] + "_";

            // Customizing the table names using the application name as a prefix
            builder.Entity<ApplicationUser>().ToTable(tablePrefix + "Users");
            builder.Entity<IdentityRole>().ToTable(tablePrefix + "Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable(tablePrefix + "UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable(tablePrefix + "UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable(tablePrefix + "UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable(tablePrefix + "RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable(tablePrefix + "UserTokens");

            // Customizing table names for application-specific entities
            builder.Entity<PostStatus>().ToTable(tablePrefix + "PostStatuses");
            builder.Entity<Category>().ToTable(tablePrefix + "Categories");
            //builder.Entity<Post>().ToTable(tablePrefix + "Posts");
            builder.Entity<Post>(entity =>
            {
                entity.ToTable(tablePrefix + "Posts");

                // Configure the PostBody column to support multiline text (e.g., using TEXT in SQL Server)
                entity.Property(p => p.PostBody).HasColumnType("VARCHAR(MAX)");
            });

            builder.Entity<Comment>().ToTable(tablePrefix + "Comments");
            builder.Entity<ArticleParsed>().ToTable(tablePrefix + "ArticleParsed");
            builder.Entity<TrashedUrl>().ToTable(tablePrefix + "TrashedUrls");
        }

    }
}
