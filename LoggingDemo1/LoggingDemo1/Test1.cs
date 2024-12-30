using Microsoft.Extensions.Logging;

namespace LoggingDemo1
{
    public class Test1
    {
        private readonly ILogger<Test1> logger;

        public Test1(ILogger<Test1> logger)
        {
            this.logger= logger;
        }

        public void Test()
        {
            logger.LogInformation("Testing");
            logger.LogDebug("testDebug");
            logger.LogError("error");
            logger.LogWarning("warning");
            
        }
    }
}
