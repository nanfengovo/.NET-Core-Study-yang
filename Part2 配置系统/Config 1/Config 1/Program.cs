using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Config_1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ServiceCollection  services = new ServiceCollection();

            services.AddScoped<TestController>();
            services.AddScoped<Test2>();
            
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("config.json",optional: true, reloadOnChange: true);
            IConfigurationRoot configRoot  = configBuilder.Build();
            #region 1、直接读取
            // string name = configRoot["name"];
            // Console.WriteLine("name:"+name);
            // string age = configRoot["age"];
            // Console.WriteLine("age:"+age);
            // string address = configRoot.GetSection("proxy:address").Value;
            // Console.WriteLine("address:"+address);
            #endregion

            #region 2-1、绑定类读取 (类：要读取的配置文件的类)

            // Proxy proxy = configRoot.GetSection("Proxy").Get<Proxy>();
            // Console.WriteLine($"{proxy.Address}, {proxy.Port}");

            #endregion

            #region 2-2、绑定类读取（整体）
            //Config config = configRoot.GetSection("Config").Get<Config>();
            // Config config = configRoot.Get<Config>();
            // Console.WriteLine(config.Name);
            // Console.WriteLine(config.Age);
            // Console.WriteLine(config.Proxy.Address);
            // Console.WriteLine(config.Proxy.Port);

            #endregion
            
            services.AddOptions()
                .Configure<Config>(e=>configRoot.Bind(e))
                .Configure<Proxy>(e => configRoot.GetSection("proxy").Bind(e));
            services.AddScoped<TestController>();
            services.AddScoped<Test2>();
            using (var sp =services.BuildServiceProvider())
            {
                var c = sp.GetRequiredService<TestController>();
                c.Test();
                var c2 = sp.GetRequiredService<Test2>();
                c2.Test();
            }

            
        }
    }
}
