using StackExchange.Redis;
using System;
using System.Configuration;

/// <summary>
/// A static class to manage Redis connection
/// </summary>
public static class RedisConnection
{
    /// <summary>
    /// A lazy-initialized ConnectionMultiplexer instance
    /// </summary>
    private static readonly Lazy<ConnectionMultiplexer> lazyConnection =
        new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect(
                ConfigurationManager.AppSettings["RedisConnection"]
            );
        });

    /// <summary>
    /// A property to get the Redis connection
    /// </summary>
    public static ConnectionMultiplexer Connection => lazyConnection.Value;
}
