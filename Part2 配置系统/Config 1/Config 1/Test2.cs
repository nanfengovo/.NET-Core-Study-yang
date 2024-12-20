using System;
using Microsoft.Extensions.Options;

namespace Config_1
{
    public class Test2
    {
        private readonly IOptionsSnapshot<Proxy> optProxy;

        public Test2(IOptionsSnapshot<Proxy> optProxy)
        {
            this.optProxy = optProxy;
        }


        public void Test()
        {
            Console.WriteLine(optProxy.Value.Address);
            Console.WriteLine(optProxy.Value.Port);
        }
        
        
    }
}
