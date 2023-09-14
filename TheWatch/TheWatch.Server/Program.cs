
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using TheWatch.Server.Data;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

/// <summary>   The builder. </summary>
var builder = WebApplication.CreateBuilder(args);

///-------------------------------------------------------------------------------------------------
/// <summary>   Default constructor. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///
/// <typeparam name="ApplicationDbContext"> Type of the application database context. </typeparam>
///-------------------------------------------------------------------------------------------------

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

///-------------------------------------------------------------------------------------------------
/// <summary>   Default constructor. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///
/// <typeparam name="ApplicationUser">  Type of the application user. </typeparam>
///-------------------------------------------------------------------------------------------------

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider)
    .AddEntityFrameworkStores<ApplicationDbContext>();

///-------------------------------------------------------------------------------------------------
/// <summary>   Default constructor. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///-------------------------------------------------------------------------------------------------

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =  JwtConstants.TokenType;
    options.DefaultChallengeScheme = JwtConstants.TokenType;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "yourIssuer", // Change this
        ValidAudience = "yourAudience", // Change this
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yourKey")) // Change this
    };
});

///-------------------------------------------------------------------------------------------------
/// <summary>   2. Set Password Requirements. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///
/// <typeparam name="IdentityOptions">  Type of the identity options. </typeparam>
///-------------------------------------------------------------------------------------------------

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
});

///-------------------------------------------------------------------------------------------------
/// <summary>
///     Add services to the container. Learn more about configuring Swagger/OpenAPI at
///     https://aka.ms/aspnetcore/swashbuckle.
/// </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///-------------------------------------------------------------------------------------------------

builder.Services.AddEndpointsApiExplorer();

///-------------------------------------------------------------------------------------------------
/// <summary>   Default constructor. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///-------------------------------------------------------------------------------------------------

builder.Services.AddSwaggerGen();

///-------------------------------------------------------------------------------------------------
/// <summary>   Default constructor. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///-------------------------------------------------------------------------------------------------

builder.Services.AddControllersWithViews();

///-------------------------------------------------------------------------------------------------
/// <summary>   Default constructor. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///-------------------------------------------------------------------------------------------------

builder.Services.AddRazorPages();

/// <summary>   The application. </summary>
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

///-------------------------------------------------------------------------------------------------
/// <summary>   Default constructor. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///-------------------------------------------------------------------------------------------------

app.UseHttpsRedirection();

///-------------------------------------------------------------------------------------------------
/// <summary>   Default constructor. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///-------------------------------------------------------------------------------------------------

app.UseAuthentication();

///-------------------------------------------------------------------------------------------------
/// <summary>   Default constructor. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///-------------------------------------------------------------------------------------------------

app.UseAuthorization();

///-------------------------------------------------------------------------------------------------
/// <summary>   Default constructor. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///-------------------------------------------------------------------------------------------------

app.UseBlazorFrameworkFiles();

///-------------------------------------------------------------------------------------------------
/// <summary>   Default constructor. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///-------------------------------------------------------------------------------------------------

app.UseStaticFiles();

///-------------------------------------------------------------------------------------------------
/// <summary>   Default constructor. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///-------------------------------------------------------------------------------------------------

app.UseRouting();

///-------------------------------------------------------------------------------------------------
/// <summary>   Default constructor. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///-------------------------------------------------------------------------------------------------

app.MapRazorPages();

///-------------------------------------------------------------------------------------------------
/// <summary>   Default constructor. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///-------------------------------------------------------------------------------------------------

app.MapControllers();

///-------------------------------------------------------------------------------------------------
/// <summary>   Constructor. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///
/// <param name="parameter1">   The first parameter. </param>
///-------------------------------------------------------------------------------------------------

app.MapFallbackToFile("index.html");

///-------------------------------------------------------------------------------------------------
/// <summary>   Default constructor. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///-------------------------------------------------------------------------------------------------

app.Run();
