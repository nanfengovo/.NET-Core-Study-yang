using System;
using System.IO;
using System.Threading.Tasks;

namespace awaitasync1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            #region 同步方法写入和读取文件
            //string filename = @"E:\Test\1.txt";
            //File.WriteAllText(filename,"hello");
            //string s = File.ReadAllText(filename);
            //Console.WriteLine(s);
            #endregion

            #region 异步方法写入和读取文件
            string filename = @"E:\Test\2.txt";
            await File.WriteAllTextAsync(filename, "hello");
            string s = await File.ReadAllTextAsync(filename);
            Console.WriteLine(s);
            #endregion

        }
    }
}
