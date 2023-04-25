using AutoMapper;
using Core.Extensions;
using Core.Localize;
using Core.Providers;
using Core.Utilities.Messages;
using Core.Utilities.Settings;
using DataAccess.Concrete.Contexts;
using Entities.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Globalization;

namespace WebAPI
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
            services.Configure<RequestLocalizationOptions>(options =>
            {
                LocalizationAppSettings settings = new LocalizationAppSettings();
                Configuration.GetSection("LocalizationAppSettings").Bind(settings);
                var cultures = new List<CultureInfo>
                {
                    new CultureInfo(Constants.LangTR),
                    new CultureInfo(Constants.LangEN)
                };
                options.DefaultRequestCulture = new RequestCulture(Constants.LangTR, Constants.LangTR);
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
                options.RequestCultureProviders = new[] { new RequestHeaderCultureProvider(settings) };
            });

            #endregion Localization

            services.AddDbContext<ECommerceDbContext>(opts => opts.UseSqlServer("Data Source =.; Initial Catalog = ECommerceDb; Integrated Security = True", options => options.MigrationsAssembly("DataAccess").MigrationsHistoryTable(HistoryRepository.DefaultTableName, "dbo")));

            services.AddControllers()
                .AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                {
                    return factory.Create(typeof(Resource));
                };
            });
            services.AddMemoryCache();
            services.AddCustomSwagger();
            services.AddCustomJwtToken(Configuration);
            services.AddCustomHttpContextAccessor();
            #region AutoMapper

            var mapperConfig = new MapperConfiguration(mc =>
              {
                  mc.AddProfile(new MappingProfile());
              });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

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
                app.UseCustomSwagger();
            }
            app.ConfigureCustomExceptionMiddleware();
            app.UseStaticHttpContext();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();//wwwroot
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}