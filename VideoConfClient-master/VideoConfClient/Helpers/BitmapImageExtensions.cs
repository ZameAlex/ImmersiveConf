using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VideoConfClient.Helpers
{
    public static class BitmapImageExtensions
    {
        public static BitmapSource Rotate(this BitmapSource image)
        {
            if (image == null)
            {
                return null;
            }

            var transformedBitmap = new TransformedBitmap();
            transformedBitmap.BeginInit();
            transformedBitmap.Source = image;
            transformedBitmap.Transform = new RotateTransform(90);
            transformedBitmap.EndInit();

            return transformedBitmap;
        }
    }
}
