using System;
using Microsoft.Extensions.Configuration;

namespace Config_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("config.json",optional: true, reloadOnChange: true);
            IConfigurationRoot configRoot  = configBuilder.Build();
            string name = configRoot["name"];
            Console.WriteLine("name:"+name);
            string age = configRoot["age"];
            Console.WriteLine("age:"+age);
            string address = configRoot.GetSection("proxy:address").Value;
            Console.WriteLine("address:"+address);
        }
    }
}
