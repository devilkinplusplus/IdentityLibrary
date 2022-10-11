using IdentityLibrary.Context;
using IdentityLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<AppUser, AppRole>().
    AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

app.UseRouting();
app.UseHttpsRedirection();

//For reaching node_modules folder
app.UseStaticFiles(new StaticFileOptions
{
    RequestPath = "/node_modules",
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(),"node_modules")
        )
});

app.UseStaticFiles();

app.MapDefaultControllerRoute();
app.UseAuthentication();
app.UseAuthorization();



app.Run();
