using System;
using Microsoft.Extensions.Options;

namespace Config_1
{
    public class TestController
    {
        private readonly IOptionsSnapshot<Config> optConfig;

        public TestController(IOptionsSnapshot<Config> optConfig)
        {
            this.optConfig = optConfig;
        }

        public void Test()
        {
            Config config = optConfig.Value;
            Console.WriteLine(optConfig.Value.Age);
            Console.WriteLine(config.Name);
            
        }
    }
}
