using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using application.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
// DBApplication conect
var connectionString = builder.Configuration.GetConnectionString("applicationIdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'applicationIdentityDbContextConnection' not found.");

builder.Services.AddDbContext<applicationIdentityDbContext>(options => options.UseSqlServer(connectionString));
//
// var applicationIdentityDbContext = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
// builder.Services.AddDbContext<applicationIdentityDbContext>(options =>
//     options.UseSqlite(connectionString));

builder.Services.AddDbContext<applicationIdentityDbContext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<applicationIdentityDbContext>();

// for ModelBuilder.Seed
// builder.Services.AddIdentity<IdentityUser, IdentityRole>(
// options => {
//     options.Stores.MaxLengthForKeys = 128;
// })
// .AddEntityFrameworkStores<applicationIdentityDbContext>()
// .AddRoles<IdentityRole>()
// .AddDefaultUI()
// .AddDefaultTokenProviders();
// 
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
