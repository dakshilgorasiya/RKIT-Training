using StackExchange.Redis;
using System;

public static class RedisConnectionHelper
{
    private static readonly Lazy<ConnectionMultiplexer> lazyConnection =
        new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect("localhost:6379");
        });

    public static ConnectionMultiplexer Connection => lazyConnection.Value;
}
