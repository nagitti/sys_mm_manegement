using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mm_manegement.Data;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite("Data source=local.db"));

}
else
{
    var host = Environment.GetEnvironmentVariable("PG_HOST");
    var db = Environment.GetEnvironmentVariable("PG_DB");
    var user = Environment.GetEnvironmentVariable("PG_USER");
    var pass = Environment.GetEnvironmentVariable("PG_PASS");

    var connStr = $"Host={host};Port=5432;Database={db};Username={user};Password={pass};Ssl Mode=Require;Trust Server Certificate=true";

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(connStr));
}
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
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
