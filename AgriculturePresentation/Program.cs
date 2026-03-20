using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.HttpOverrides;

namespace AgriculturePresentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AgricultureContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IAboutDal, EfAboutDal>();
            builder.Services.AddScoped<IAddressDal, EfAddressDal>();
            builder.Services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
            builder.Services.AddScoped<IContactDal, EfContactDal>();
            builder.Services.AddScoped<IGalleryImageDal, EfGalleryImageDal>();
            builder.Services.AddScoped<IServiceDal, EfServiceDal>();
            builder.Services.AddScoped<ITeamDal, EfTeamDal>();
            builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

            builder.Services.AddIdentity<AppUser, IdentityRole>()
                        .AddEntityFrameworkStores<AgricultureContext>();

            builder.Services.ContainerDependencies();

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute());

                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/Index/";
                options.LogoutPath = "/Login/Logout/";
                options.Cookie.Name = ".Agriculture.Session";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(45);
                options.SlidingExpiration = true;
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

            builder.Services.AddRateLimiter(options =>
            {
                options.AddFixedWindowLimiter("ContactFormLimit", permitLimitOptions =>
                {
                    permitLimitOptions.PermitLimit = 3;
                    permitLimitOptions.Window = TimeSpan.FromMinutes(1);
                    permitLimitOptions.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    permitLimitOptions.QueueLimit = 0;
                });

                options.OnRejected = async (context, token) =>
                {
                    context.HttpContext.Response.StatusCode = 429;
                    context.HttpContext.Response.ContentType = "text/plain; charset=utf-8";
                    await context.HttpContext.Response.WriteAsync("Çok fazla istek gönderdiniz. Lütfen 1 dakika bekleyip tekrar deneyin.", token);
                };
            });

            builder.Services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.KnownIPNetworks.Clear();
                options.KnownProxies.Clear();
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseForwardedHeaders();
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404");
            app.UseRouting();

            app.UseRateLimiter();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Default}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}