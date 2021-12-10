using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LruCache
{
    class EntryPoint
    {
        static void Main()
        {
            /*
             * Input
                ["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
                [[2],       [1, 1], [2, 2], [1],  [3, 3],  [2], [4, 4], [1],   [3],   [4]]
                Output
                [null, null, null, 1, null, -1, null, -1, 3, 4]
             */

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var cache = new LruCache(2);

            cache.Put(1, 1);
            cache.Put(2, 2);
            Console.WriteLine(cache.Get(1));
            cache.Put(3, 3);
            Console.WriteLine(cache.Get(2));
            cache.Put(4, 4);
            Console.WriteLine(cache.Get(1));
            Console.WriteLine(cache.Get(3));
            Console.WriteLine(cache.Get(4));

            stopWatch.Stop();
            Console.WriteLine($"elapsed time: {stopWatch.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }
    }
}
