using System.Configuration;

namespace VideoConfClient.Helpers
{
    /// <summary>
    /// Wrapper class for working with App.config
    /// </summary>
    public static class AppConfig
    {
        /// <summary>
        /// Server Main Image Endpoint
        /// </summary>
        public static string ServerEndpoint
        {
            get
            {
                return ConfigurationManager.AppSettings["ServerMainImageEndpoint"];
            }
        }

        /// <summary>
        /// Represents position of main image (without rotation).
        /// Numeration starts from 0 - left image (1 - top image, 2 - right image, 3 - bottom image).
        /// </summary>
        public static int MainImageIndex
        {
            get
            {
                int index;
                int.TryParse(ConfigurationManager.AppSettings["MainImageIndex"], out index);
                return index;
            }
        }

        /// <summary>
        /// Represents aspect ratio of main image.
        /// </summary>
        public static double MainImageAspectRatio
        {
            get
            {
                double ratio;
                double.TryParse(ConfigurationManager.AppSettings["AspectRatio"], out ratio);
                return ratio;
            }
        }
    }
}
