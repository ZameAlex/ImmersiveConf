using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using VideoConfClient.Helpers;
using WebSocketSharp;

namespace VideoConfClient.Core
{
    /// <summary>
    /// Main class that will be interact with main window.
    /// We don't use MVVM for better performance.
    /// </summary>
    public class MainWindowInteraction
    {
        private Image[] viewImages;
        private WebSocketClient wsClient;

        public MainWindowInteraction(params Image[] images)
        {
            viewImages = images;
            wsClient = new WebSocketClient();
            wsClient.OnMessage += OnMessage;
            wsClient.Connect();
        }

        public void Close()
        {
            wsClient.Close();
        }

        private void OnMessage(object sender, MessageEventArgs e)
        {
            if (e.IsBinary)
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Input,
                    new Action(() => UpdateImages(e.RawData)));
            }
        }

        private void UpdateImages(byte[] imageBytes)
        {
            var originalImageIndex = AppConfig.MainImageIndex;
            var originalImage = imageBytes.ToBitmapImage();
            viewImages[originalImageIndex].Source = originalImage;

            for (int i = originalImageIndex + 1; i < viewImages.Length + originalImageIndex; i++)
            {
                var rotated = originalImage.Rotate();
                viewImages[i % viewImages.Length].Source = rotated;
                originalImage = rotated;
            }
        }
    }
}
