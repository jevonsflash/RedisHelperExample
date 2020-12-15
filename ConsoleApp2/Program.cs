using ColinChang.RedisHelper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static private IRedisHelper redis;
            
        static async Task Main(string[] args)
        {
            redis =
              new RedisHelper(
                  "127.0.0.1:6379,password=,connectTimeout=1000,connectRetry=1,syncTimeout=10000");
            for (int i = 0; i < 18; i++)
            {
                Thread.Sleep(2000);
                await LockExecuteTestAsync();

            }
            Console.ReadKey();
        }

        static async Task LockExecuteTestAsync()
        {
            
            const string channel = "message";
            const string message = "hi there";
            await redis.PublishAsync(channel, message);
            Console.WriteLine($" msg has been send channel: {channel} msg:{message} \t{DateTime.Now.ToLongTimeString()}");

           

        }
    }
}
