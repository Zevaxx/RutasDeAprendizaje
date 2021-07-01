using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
//using RutasDeAprendizaje.Data;
using RutasDeAprendizaje.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RutasDeAprendizaje.Models.DBModels;
using RutasDeAprendizaje.Helpers;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace RutasDeAprendizaje
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      // Replace with your connection string.
      var connectionString = Configuration.GetConnectionString("DefaultConnection");

      // Replace with your server version and type.
      // Use 'MariaDbServerVersion' for MariaDB.
      // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
      // For common usages, see pull request #1233.
      var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));

      // Replace 'YourDbContext' with the name of your own DbContext derived class.
      services.AddDbContext<RutasdeaprendizajeContext>(
          dbContextOptions => dbContextOptions
            .UseMySql(connectionString, serverVersion)
            .EnableSensitiveDataLogging() // <-- These two calls are optional but help
             .EnableDetailedErrors()       // <-- with debugging (remove for production).
        );


            services.Configure<IdentityOptions>(options =>
           {
               options.Password.RequiredLength = 5;
               options.Password.RequireNonAlphanumeric = false;
               options.Password.RequireLowercase = false;
               options.Password.RequireUppercase = false;
               options.Password.RequireDigit = false;
           }
            );
      
                services.AddDatabaseDeveloperPageExceptionFilter();

      services.AddDefaultIdentity<Tuser>(options => options.SignIn.RequireConfirmedAccount = true)
          //.AddDefaultUI()
          .AddRoles<IdentityRole>()
          .AddRoleManager<RoleManager<IdentityRole>>()
          //.AddDefaultTokenProviders()
          .AddEntityFrameworkStores<RutasdeaprendizajeContext>();

            services.AddIdentityServer()
             .AddApiAuthorization<Tuser, RutasdeaprendizajeContext>()
             .AddProfileService<ProfileService>();


            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication()
              .AddJwtBearer(cfg =>
              {
                  cfg.TokenValidationParameters = new TokenValidationParameters
                  {
                   
                    RoleClaimType = "role"  
                   
                  };
              }).AddIdentityServerJwt();

            services.AddControllersWithViews();
            services.AddRazorPages();

        // In production, the React files will be served from this directory
        services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "ClientApp/build";
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseMigrationsEndPoint();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseSpaStaticFiles();

      app.UseRouting();

        app.UseIdentityServer();
        app.UseAuthentication();
        app.UseAuthorization();
            
      

      //app.UseStatusCodePages();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller}/{action=Index}/{id?}");
        endpoints.MapRazorPages();
      });

      app.UseSpa(spa =>
      {
        spa.Options.SourcePath = "ClientApp";

        if (env.IsDevelopment())
        {
          spa.UseReactDevelopmentServer(npmScript: "start");
        }
      });
    }
  }
}
