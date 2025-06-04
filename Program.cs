using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using lilgobguides.Data;

var builder = WebApplication.CreateBuilder(args);

string dbConnection = null!;
if (builder.Environment.IsDevelopment())
{
    dbConnection = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("No database connection string");
}
else if (builder.Environment.IsProduction())
{
    dbConnection = builder.Configuration["lilgobguides_DATABASE_PATH"]
    ?? throw new InvalidOperationException("Is there environment variable for database path?");
}
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(dbConnection));

builder.Services.AddDefaultIdentity<IdentityUser>(
    options => options.SignIn.RequireConfirmedAccount = false)
        .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddRazorPages();
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
                  .GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
