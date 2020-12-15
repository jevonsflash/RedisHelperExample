using ColinChang.RedisHelper;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await LockExecuteTestAsync();
            Console.ReadKey();
        }

        static async Task LockExecuteTestAsync()
        {
            IRedisHelper redis =
              new RedisHelper(
                  "127.0.0.1:6379,password=,connectTimeout=1000,connectRetry=1,syncTimeout=10000");
            Console.WriteLine($"redis connected \t{DateTime.Now.ToLongTimeString()}");

            const string channel = "message";
            const string message = "hi there";
            await redis.SubscribeAsync(channel, (chn, msg) =>
            {
                Console.WriteLine($"msg has recived channel: {channel} msg:{msg} \t{DateTime.Now.ToLongTimeString()}");

              
            });
        }
    }
}
