using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vineeth.Data;
using Vineeth.Models;
using Vineeth.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<AppilicationDbcontext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("mycon")));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppilicationDbcontext>();
builder.Services.Configure<IdentityOptions>(optioins =>
{
    optioins.Password.RequiredLength =5;
    optioins.Password.RequiredUniqueChars = 1;
    optioins.Password.RequireDigit = false;
    optioins.Password.RequireLowercase = false;
    optioins.Password.RequireNonAlphanumeric = false;
    optioins.Password.RequireUppercase=false;
});
//builder.Services.ConfigureApplicationCookie(config =>
//{
//    config.LoginPath="Sigin";
//});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
