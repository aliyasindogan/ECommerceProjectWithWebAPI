using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.Exceptions;

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
                string _token = _httpContextAccessor.HttpContext.Session.GetString("token");
                if (!String.IsNullOrEmpty(_token))
                {
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