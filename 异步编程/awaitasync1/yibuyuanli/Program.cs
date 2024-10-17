using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace yibuyuanli
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (HttpClient httpClient = new HttpClient())
            { 
                string html = await httpClient.GetStringAsync("https://www.baidu.com");
                Console.WriteLine(html);
            }
            string txt = "hello world";
            string filename = @"E:\Test\2.txt";
            await File.WriteAllTextAsync(filename, txt);
            string content = await File.ReadAllTextAsync(filename);
            Console.WriteLine(content);
        }
    }
}
