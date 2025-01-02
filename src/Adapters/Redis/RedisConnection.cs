using StackExchange.Redis;

namespace Redis;
public class RedisConnection
{
    private static Lazy<ConnectionMultiplexer> _lazyConnection;
    private RedisConnection() { }

    //public static void Initialize(string connectionString)
    //{
    //    if (_lazyConnection != null)
    //    {
    //        throw new InvalidOperationException("RedisConnection já foi inicializado.");
    //    }

    //    _lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
    //    {
    //        return ConnectionMultiplexer.Connect(connectionString);
    //    });
    //}

    //public static ConnectionMultiplexer Instance
    //{
    //    get
    //    {
    //        if (_lazyConnection == null)
    //        {
    //            throw new InvalidOperationException("RedisConnection não foi inicializado. Use Initialize primeiro.");
    //        }

    //        return _lazyConnection.Value;
    //    }
    //}

    //public static void Dispose()
    //{
    //    if (_lazyConnection?.IsValueCreated ?? false)
    //    {
    //        _lazyConnection.Value.Dispose();
    //    }

    //    _lazyConnection = null;
    //}
}