using System.Configuration;

namespace Helpers
{
    public static class AppConfigHelper
    {
        public static string ServerEndPoint
        {
            get
            {
                return ConfigurationManager.AppSettings["ServerMainImageEndpoint"];
            }
        }

        public static string MainPath
        {
            get
            {
                return ConfigurationManager.AppSettings["ServerMainPath"];
            }
        }

    }
}
