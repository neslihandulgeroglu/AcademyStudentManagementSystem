using ASMSDataAccessLayer;
using ASMSEntityLayer.IdentityModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ASMSEntityLayer.Mappings;
using ASMSBusinessLayer.EmailService;

namespace ASMSPresentationLayer
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
            //ASPnet Core'un ConnectionString baðlantýsý yapabilmesi iiçin
            //yapýladýrma servislerine dbcontext nesnesini eklenmesi gerekir.
            services.AddDbContext<MyContext>(options => options.UseSqlServer
            (Configuration.GetConnectionString("SqlConnection")));
            services.AddControllersWithViews();
            services.AddControllersWithViews();
            services.AddRazorPages();//Razor sayfalarý için
            services.AddMvc();
            services.AddSession(options =>
            options.IdleTimeout = TimeSpan.FromSeconds(20));
            services.AddIdentity<AppUser, AppRole>(options =>
             {
                 options.User.RequireUniqueEmail = true;
                 options.Password.RequiredLength = 3;
                 options.Password.RequireLowercase = false;
                 options.Password.RequireUppercase = false;
                 options.Password.RequireNonAlphanumeric = false;
                 options.Password.RequireDigit = false;
                 options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
             }).AddDefaultTokenProviders().AddEntityFrameworkStores<MyContext>();

            //mapleme eklendi
            services.AddAutoMapper(typeof(Maps));
            services.AddScoped<IEmailSender,EmailSender>();
            
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//wwwroot klasörünün eriþimi


            app.UseRouting();//Controller/Action
            app.UseSession();//Oturum mekanýzmasýnýn kulllanýlmasý için 
            app.UseAuthorization();//[Authorize ]attribute için (yetki)
            app.UseAuthentication();//Login Logout Ýþlemlerinin gerektirdiði oturum iþleyiþlerini kullanabilmek için.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
