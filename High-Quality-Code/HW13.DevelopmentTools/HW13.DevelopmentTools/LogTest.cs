namespace HW13.DevelopmentTools
{
    using log4net;
    using log4net.Config;

    public class LogTest
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (LogTest));

        public LogTest()
        {
            BasicConfigurator.Configure();
            logger.Debug("Sample debug log");
            logger.Info("Info log...");
            logger.Warn("Warning log...");
            logger.Error("Error log...");
            logger.Fatal("Fatal log...");
        }
    }
}
