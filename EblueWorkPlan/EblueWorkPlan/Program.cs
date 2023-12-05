using EblueWorkPlan.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WorkplandbContext>(options =>
{


    options.UseSqlServer(builder.Configuration.GetConnectionString("WorkPlanContext"));

});

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(option => {
//        option.LoginPath = "Home/Signin";
//        option.ExpireTimeSpan = TimeSpan.FromMinutes(5);
//        option.AccessDeniedPath = "Home/Privacy";
//    });

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


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Signin}/{id?}");

IWebHostEnvironment env = app.Environment;

app.Run();
