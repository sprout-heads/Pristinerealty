using Pristinerealty.Entity.Model;
using Pristinerealty.Web.Pages;
using Pristinerealty.Repository;
using Pristinerealty.Repository.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pristinerealty.Web
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
            services.AddSession();
            services.AddControllers();
            services.Configure<AppSettings>(Configuration);
            services.AddSingleton<AppSettings>();
            services.AddControllersWithViews();


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options =>
              {
                  options.Cookie.Name = "MySessionCookie";
                  options.LoginPath = "/Login";
                  options.SlidingExpiration = true;
              });


            services.AddRazorPages()
        .AddRazorPagesOptions(options =>
         {
             options.Conventions.AuthorizePage("/Admin/Create");
             options.Conventions.AuthorizePage("/Admin/Edit");
             options.Conventions.AuthorizePage("/Admin/Gallery");
             options.Conventions.AuthorizePage("/Admin/Index");
             options.Conventions.AuthorizePage("/Admin/CV");

             options.Conventions.AllowAnonymousToPage("/Index");
         });

            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IGalleryRepository, GalleryRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IResumeRepository, ResumeRepository>();

            services.AddTransient<IDapperService, DapperService>();

          //  var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
           // var config = builder.Build();

          //  services.AddTransient(f => new Entity.Model.ConnectionString(config["ConnectionString:DefaultConnection"]));



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.None,
            };

            app.UseCookiePolicy(cookiePolicyOptions);


            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Login}/{action=Index}/{id?}");
            //});


        }
    }
}
