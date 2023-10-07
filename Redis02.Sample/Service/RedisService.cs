using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redis02.Sample.Service
{
    public class RedisService
    {
        ConnectionMultiplexer connectionMultiplexer;
        public void Connect() => connectionMultiplexer = ConnectionMultiplexer.Connect("localhost:6379");
        public IDatabase GetDb(int db) => connectionMultiplexer.GetDatabase(db);
    }
}
