using Demo.AhphOcelot.Configuration;
using Demo.AhphOcelot.Extensions;
using Ocelot.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.AhphOcelot.Cache
{
   public class InRedisCache<T>:IOcelotCache<T>
    {
        private readonly AhphOcelotConfiguration _options;
        public InRedisCache(AhphOcelotConfiguration options)
        {
            _options = options;
            CSRedis.CSRedisClient csredis;
            if (options.RedisConnectionStrings.Count == 1)
            {
                //普通模式
                csredis = new CSRedis.CSRedisClient(options.RedisConnectionStrings[0]);
            }
            else
            {
                //集群模式
                //实现思路：根据key.GetHashCode() % 节点总数量，确定连向的节点
                //也可以自定义规则(第一个参数设置)
                csredis = new CSRedis.CSRedisClient(null, options.RedisConnectionStrings.ToArray());
            }
            //初始化 RedisHelper
            RedisHelper.Initialization(csredis);
        }

        public void Add(string key, T value, TimeSpan ttl, string region)
        {
            key = GetKey(region, key);
            if (ttl.TotalMilliseconds <= 0)
            {
                return;
            }
            RedisHelper.Set(key, value.ToJson(), (int)ttl.TotalSeconds);
        }

        public void AddAndDelete(string key, T value, TimeSpan ttl, string region)
        {
            Add(key, value, ttl, region);
        }

        public void ClearRegion(string region)
        {
            //获取所有满足条件的key
            var data = RedisHelper.Keys(_options.RedisKeyPrefix + "-" + region + "-*");
            //批量删除
            RedisHelper.Del(data);
        }

        public T Get(string key, string region)
        {
            key = GetKey(region, key);
            var result = RedisHelper.Get(key);
            if (!String.IsNullOrEmpty(result))
            {
                return result.ToObject<T>();
            }
            return default(T);
        }

        /// <summary>
        /// 获取格式化后的key
        /// </summary>
        /// <param name="region">分类标识</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        private string GetKey(string region, string key)
        {
            return _options.RedisKeyPrefix + "-" + region + "-" + key;
        }
    }
}
