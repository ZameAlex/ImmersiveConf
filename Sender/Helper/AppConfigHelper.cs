using System.Configuration;

namespace Conference.Helper
{

    public static class AppConfigHelper
    {
        public static string ServerEndPoint
        {
            get
            {
                return ConfigurationManager.AppSettings["ServerEndpoint"];
            }
        }

        public static string MainPath
        {
            get
            {
                return ConfigurationManager.AppSettings["MainPath"];
            }
        }

    }
}
