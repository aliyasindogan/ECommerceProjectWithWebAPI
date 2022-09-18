using Core.Utilities.Exceptions;
using Core.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPIWithCoreMvc.Handler
{
    public class AuthTokenHandler : DelegatingHandler
    {
        public AuthTokenHandler()
        {
        }

        private IHttpContextAccessor _httpContextAccessor;

        public AuthTokenHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var name = _httpContextAccessor.HttpContext.User.Identity.Name;
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                string _language = _httpContextAccessor.HttpContext.User.FindFirst("language").Value;
                string _token = _httpContextAccessor.HttpContext.User.FindFirst("token").Value;
                if (!string.IsNullOrEmpty(_token))
                {
                    request.Headers.Add(Constants.AcceptLangauge, _language);
                    request.Headers.Add("Authorization", $"Bearer {_token}");
                }
            }
            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnAuthorizeException();
            }
            return response;
        }
    }
}