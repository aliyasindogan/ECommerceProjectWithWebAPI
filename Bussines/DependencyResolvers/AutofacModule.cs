using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.CrossCuttingConcers.Caching;
using Core.CrossCuttingConcers.Caching.Microsoft;
using Core.Utilities.Interceptors;
using Core.Utilities.Localization;
using Core.Utilities.Security.Token;
using Core.Utilities.Security.Token.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.Localization;

namespace Business.DependencyResolvers
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfAppUserDal>().As<IAppUserDal>();
            builder.RegisterType<AppUserService>().As<IAppUserService>();

            builder.RegisterType<AppUserTypeService>().As<IAppUserTypeService>();
            builder.RegisterType<EfAppUserTypeDal>().As<IAppUserTypeDal>();

            builder.RegisterType<EfPageDal>().As<IPageDal>();
            builder.RegisterType<PageService>().As<IPageService>();

            builder.RegisterType<EfPageTypeDal>().As<IPageTypeDal>();
            builder.RegisterType<PageTypeService>().As<IPageTypeService>();

            builder.RegisterType<EfLanguageDal>().As<ILanguageDal>();
            builder.RegisterType<LanguageService>().As<ILanguageService>();

            builder.RegisterType<EfPageLanguageDal>().As<IPageLanguageDal>();
            builder.RegisterType<PageLanguageService>().As<IPageLanguageService>();

            builder.RegisterType<JwtTokenService>().As<ITokenService>();
            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<MemoryCacheService>().As<ICacheService>();
            builder.RegisterType<FileLogger>();
            builder.RegisterType<LocalizationService>().As<ILocalizationService>();
            builder.RegisterGeneric(typeof(StringLocalizer<>)).As(typeof(IStringLocalizer<>)).SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterseptorSelector()
                }).SingleInstance();
        }
    }
}