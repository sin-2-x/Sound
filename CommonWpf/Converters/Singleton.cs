namespace CommonWpf.Converters
{
    public class Singleton<T> where T : class, new()
    {
        protected static T instance;

        public static T Instance => instance ?? (instance = new T());
    }
}
