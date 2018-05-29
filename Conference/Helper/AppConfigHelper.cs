using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
