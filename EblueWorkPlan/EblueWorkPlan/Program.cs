using EblueWorkPlan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using EblueWorkPlan.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<PermissionService>();
builder.Services.AddScoped<PermissionAccessService>();
builder.Services.AddDbContext<WorkplandbContext>(
      options => options.UseSqlServer(builder.Configuration.GetConnectionString("WorkPlanContext")));

builder.Services.AddAuthentication().AddMicrosoftAccount(opciones => 
{
    opciones.ClientId = builder.Configuration["MicrosoftClientId"]!;
    opciones.ClientSecret = builder.Configuration["MicrosoftSecretId"]!;
});




builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    // Relaja las reglas del nombre de usuario
    options.User.AllowedUserNameCharacters = null;
    options.User.RequireUniqueEmail = false; 

    // Relaja las reglas de la contraseña (opcional)
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;



})
               .AddEntityFrameworkStores<WorkplandbContext>()
               .AddDefaultTokenProviders();

builder.Services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
    option =>
    {
        option.LoginPath = "/Login/Signin"; 
        option.AccessDeniedPath = "/Home/Privacy";
    });





builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Login/Signin";
        
        option.AccessDeniedPath = "/Home/Privacy";
    });

var app = builder.Build();



#region depreciated
//builder.Services.AddDbContext<WorkplandbContext>(options =>
//{


//    options.UseSqlServer(builder.Configuration.GetConnectionString("WorkPlanContext"));

//});

#endregion



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
    pattern: "{controller=Login}/{action=Signin}/{id?}");



IWebHostEnvironment env = app.Environment;

app.Run();
