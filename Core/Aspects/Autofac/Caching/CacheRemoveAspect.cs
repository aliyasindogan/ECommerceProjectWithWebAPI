using System.Diagnostics;
using System.Linq;
using Castle.DynamicProxy;
using Core.CrossCuttingConcers.Caching;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _methodName;
        private readonly ICacheService _cacheService;

        public CacheRemoveAspect(string methodName)
        {
            _methodName = methodName;
            _cacheService = (ICacheService)Utilities.Helpers.HttpContext.Current.RequestServices.GetService(typeof(ICacheService));
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            string[] methods = _methodName.Split(',');
            foreach (string method in methods)
              _cacheService.Remove($"Business.Abstract.{method}()");
        }
    }
}