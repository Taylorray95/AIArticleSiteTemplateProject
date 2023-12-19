using AIArticleSiteTemplateProject.Client.Pages;
using AIArticleSiteTemplateProject.Components;
using AIArticleSiteTemplateProject.Components.Account;
using AIArticleSiteTemplateProject.Data;
using AIArticleSiteTemplateProject.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<PostService>();
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    options.UseSqlServer(connectionString);
    options.ReplaceService<IModelCacheKeyFactory, DynamicModelCacheKeyFactory>();
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
builder.Services.AddScoped<BlobServiceClientWrapper>();

builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<SignInManager<ApplicationUser>, CustomSignInManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    await EnsureRolesAsync(roleManager);
    await AssignSuperUserRoleAsync(userManager);
}

async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
{
    string[] roles = new[] { "SuperAdmin", "Admin", "Moderator" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            var newRole = new IdentityRole(role);
            await roleManager.CreateAsync(newRole);
        }
    }
}
async Task AssignSuperUserRoleAsync(UserManager<ApplicationUser> userManager)
{
    //once you have created your account, enter your email below and rerun the application to get your superuserrole which will give you access to do everything in the app 
    //function can handle a list of users
    var superUserEmails = new List<string>
    {
        "taylorleavelle@gmail.com"
    };

    foreach (var superUserEmail in superUserEmails)
    {
        try
        {
            var user = await userManager.FindByEmailAsync(superUserEmail);
            if (user == null)
            {
                Console.WriteLine($"User with email {superUserEmail} not found.");
                continue;
            }

            if (!await userManager.IsInRoleAsync(user, "SuperAdmin"))
            {
                var result = await userManager.AddToRoleAsync(user, "SuperAdmin");
                if (result.Succeeded)
                {
                    Console.WriteLine($"User {superUserEmail} assigned to role successfully.");
                }
                else
                {
                    Console.WriteLine($"Error assigning role to {superUserEmail}: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
            else
            {
                Console.WriteLine($"User {superUserEmail} already has the role.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception occurred while processing {superUserEmail}: " + ex.Message);
        }
    }
}


app.Run();
