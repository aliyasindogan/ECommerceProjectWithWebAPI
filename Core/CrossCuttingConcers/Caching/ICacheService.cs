namespace Core.CrossCuttingConcers.Caching
{
    public interface ICacheService
    {
        T Get<T>(string key);

        object Get(string key);

        void Add(string key, object data, int duration);

        bool IsAdd(string key);

        void Remove(string key);
       
    }
}