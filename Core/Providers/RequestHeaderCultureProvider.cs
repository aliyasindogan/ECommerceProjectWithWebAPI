using Core.Utilities.Messages;
using Core.Utilities.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Threading.Tasks;

namespace Core.Providers
{
    public class RequestHeaderCultureProvider : RequestCultureProvider
    {
        public string HeaderName { get; set; } = Constants.AcceptLangauge;
        private LocalizationAppSettings _appsetting;

        public RequestHeaderCultureProvider(LocalizationAppSettings settings)
        {
            _appsetting = settings;
        }

        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));
           
            var localizationHeader = httpContext.Request.Headers[HeaderName];
            if (localizationHeader.Count == 0)
            {
                return Task.FromResult((ProviderCultureResult)null);
            }

            var cultureResult = ParseHeaderValue(localizationHeader);
            return Task.FromResult(cultureResult);
        }

        private ProviderCultureResult DefaultCulture()
        {
            return new ProviderCultureResult(Constants.LangTR, Constants.LangTR);
        }

        private ProviderCultureResult ParseHeaderValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return DefaultCulture();
            }
            var cultureName = value.Split(";")[0].Split(",")[0].ToLower();
            if (string.IsNullOrEmpty(cultureName) || !_appsetting.Cultures.ContainsKey(cultureName))
                return DefaultCulture();

            cultureName = _appsetting.Cultures[cultureName];
            var uiCultureName = cultureName;
            return new ProviderCultureResult(cultureName, uiCultureName);
        }
    }
}