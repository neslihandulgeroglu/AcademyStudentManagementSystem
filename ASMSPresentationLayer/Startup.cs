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
using ASMSBusinessLayer.ImplementationsBLL;
using ASMSBusinessLayer.ContractsBLL;

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
            //ASPnet Core'un ConnectionString ba?lant?s? yapabilmesi ii?in
            //yap?lad?rma servislerine dbcontext nesnesini eklenmesi gerekir.
            services.AddDbContext<MyContext>(options => options.UseSqlServer
            (Configuration.GetConnectionString("SqlConnection")));
            services.AddControllersWithViews().AddRazorRuntimeCompilation();//pROJE ?ALI?IRKEN RAZOR SAYFALARINI
            //YAPILAN DE????KL?KLER? anasayfaya yans?mas? i?in.
            services.AddRazorPages();//Razor sayfalar? i?in
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
            services.AddSingleton<IEmailSender,EmailSender>();
            services.AddScoped<IStudentBusinessEngine, StudentBusinessEngine>();
            services.AddScoped<IUsersAddressBusinessEngine, UsersAddressBusinessEngine>();
            services.AddScoped<ICityBusinessEngine, CityBusinessEngine>();
            services.AddScoped<IDistrictBusinessEngine, DistrictBusinessEngine>();
            services.AddScoped<INeighbourhoodBusinessEngine, NeighbourhoodBusinessEngine>();


            services.AddScoped<ASMSDataAccessLayer.ContractsDAL.IUnitOfWork, ASMSDataAccessLayer.ImplementationsDAL.UnitOfWork>();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,RoleManager<AppRole>roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//wwwroot klas?r?n?n eri?imi


            app.UseRouting();//Controller/Action
            app.UseSession();//Oturum mekan?zmas?n?n kulllan?lmas? i?in 
            app.UseAuthentication();//Login Logout ??lemlerinin gerektirdi?i oturum i?leyi?lerini kullanabilmek i?in.
            app.UseAuthorization();//[Authorize ]attribute i?in (yetki)
             //rolleri olu?turacak ststic metot ?a??r?ld?.
            CreateDefaultData.CreateData.Create(roleManager);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    "management",
                    "management",
                    "management/{controller=Admin}/{action=Register}/{id?}"
                    );
                //endpoints.MapAreaControllerRoute(
                //    name: "management",
                //    areaName: "management",
                //    pattern: "{area:management},{controller=Admin}/{action=Login}/{id?}");

            });
           
        }
    }
}
