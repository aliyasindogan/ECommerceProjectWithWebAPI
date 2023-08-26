using System;
using Core.Utilities.Settings;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPIWithCoreMvc.ApiServices;
using WebAPIWithCoreMvc.ApiServices.Interfaces;
using WebAPIWithCoreMvc.Handler;
using Core.Utilities.Messages;
using CookieRequestCultureProvider = Core.Providers.CookieRequestCultureProvider;
using Core.Utilities.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using AutoMapper;
using Entities.Mappings;
using WebAPIWithCoreMvc.Mappings;

namespace WebAPIWithCoreMvc
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
            #region Localization

            services.AddLocalization(options => { options.ResourcesPath = "Resources"; });
            LocalizationAppSettings settings = new LocalizationAppSettings();
            Configuration.GetSection("LocalizationAppSettings").Bind(settings);

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var cultures = new List<CultureInfo>
                {
                    new CultureInfo(Constants.LangTR),
                    new CultureInfo(Constants.LangEN)
                };
                options.DefaultRequestCulture = new RequestCulture(Constants.LangTR, Constants.LangTR);
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
                options.AddInitialRequestCultureProvider(new CookieRequestCultureProvider(settings));
            });

            #endregion Localization
            services.AddControllersWithViews().AddRazorRuntimeCompilation(); ;
            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddScoped<AuthTokenHandler>();
            services.AddTransient<IAuthApiService, AuthApiService>();
            services.AddTransient<IAppUserApiService, AppUserApiService>();
            services.AddTransient<IAppUserTypeApiService, AppUserTypeApiService>();
            services.AddTransient<IPageApiService, PageApiService>();
            services.AddTransient<IPageTypeApiService, PageTypeApiService>();
            services.AddTransient<IPageLanguageApiService, PageLanguageApiService>();
            services.AddTransient<ILanguageApiService,LanguageApiService>();
            services.AddTransient<IUploadImageApiService, UploadImageApiService>();
            services.AddSingleton<ILocalizationService, LocalizationService>();
            services.AddSingleton(typeof(IStringLocalizer<>), typeof(StringLocalizer<>));
            
            #region HttpClient
            services.AddHttpClient<IHttpClientService, HttpClientService>(opt =>
            {
                opt.BaseAddress = new Uri(settings.BaseUrl);

            }).AddHttpMessageHandler<AuthTokenHandler>();
            #endregion HttpClient

            #region Cookie

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
                {
                    opt.LoginPath = "/Admin/Auth/Login";
                    opt.ExpireTimeSpan = TimeSpan.FromDays(60);
                    opt.SlidingExpiration = true;
                    opt.Cookie.Name = "mvccookie";
                });

            #endregion Cookie

            #region AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //var mapperConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new MappingProfile());
            //});
            //var mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);

            #endregion AutoMapper
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizationOptions.Value);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseExceptionHandler("/Home/Error");
            //app.UseStatusCodePagesWithRedirects("/Admin/Error/MyStatusCode?code={0}");
            app.UseSession();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                //Admin/Home/Index
                endpoints.MapAreaControllerRoute(
                    areaName: "Admin",
                    name: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                );
                //Home/Index
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}