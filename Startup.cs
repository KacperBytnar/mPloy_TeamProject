using mPloy_TeamProjectG5.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mPloy_TeamProjectG5.Services.EFServices;
using mPloy_TeamProjectG5.Services.Interfaces;

namespace mPloy_TeamProjectG5
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
            services.AddRazorPages();

            services.AddTransient<IUserService, EFUserService>();
            services.AddTransient<ITaskService, EFTaskService>();
            services.AddTransient<IBidService, EFBidService>();



            IServiceCollection serviceCollection = services.AddHttpContextAccessor();


            services.AddIdentity<AppUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<AppDbContext>();
            //.AddDefaultTokenProviders()
            //.AddRoles<IdentityRole<int>>();
            services.AddAuthentication("CookiesUserAuth").AddCookie("CookiesUserAuth",
        options =>
        {
            options.Cookie.Name = "CookiesUserAuth";
            options.LoginPath = "/UserAccount/Login";
        });
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/UserAccount/AccountLogIn";
                options.Cookie.Name = "YourAppCookieName";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/UserAccount/AccountLogIn";
                // ReturnUrlParameter requires 
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AppDbContext")));
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseSession();
            //app.UseMvc();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
