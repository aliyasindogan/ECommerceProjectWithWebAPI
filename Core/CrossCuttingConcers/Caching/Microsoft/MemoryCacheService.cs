using Microsoft.Extensions.Caching.Memory;
using System;

namespace Core.CrossCuttingConcers.Caching.Microsoft
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheService()
        {
            _memoryCache =
                (IMemoryCache)Utilities.Helpers.HttpContext.Current.RequestServices.GetService(typeof(IMemoryCache));
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public void Add(string key, object data, int duration)
        {
            _memoryCache.Set(key, data, TimeSpan.FromMinutes(duration));
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

    }
}