using Application.Caching;
using StackExchange.Redis;
using System.Text.Json;

namespace Infrastructure;
public class RedisCacheManager : ICacheManager
{
    private readonly IDatabase _database;
    private readonly IConnectionMultiplexer _redisConnection;
    public RedisCacheManager(IConnectionMultiplexer redis)
    {
        _database = redis.GetDatabase();
        _redisConnection = redis;
    }

    public T? Get<T>(string key)
    {
        var value = _database.StringGet(key);
        return value.HasValue ? JsonSerializer.Deserialize<T>(value) : default;
    }

    public void Set<T>(string key, T value, TimeSpan expiration)
    {
        var json = JsonSerializer.Serialize(value);
        _database.StringSet(key, json, expiration);
    }

    public void Remove(string key)
    {
        _database.KeyDelete(key);
    }
    public void DeleteKeysByPrefix(string prefix)
    {
        var server = _redisConnection.GetServer(_redisConnection.GetEndPoints().First());

        var keys = server.Keys(pattern: $"{prefix}*").ToArray();

        foreach (var key in keys)
        {
            _database.KeyDelete(key);
        }
    }
}
