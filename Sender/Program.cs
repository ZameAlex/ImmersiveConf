using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;

namespace Sender
{
    class Program
    {

        private static Sender senderSocket = new Sender();
        private static List<FilterInfo> GetCamerasList()
        {
            FilterInfoCollection cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            var result = new List<FilterInfo>();
            foreach(FilterInfo cam in cameras)
            {
                result.Add(cam);
            }
            return result;
        }


        static void Main(string[] args)
        {
            var camerasInfo = GetCamerasList();
            int number = 1;
            foreach(var item in camerasInfo)
            {

                Console.WriteLine($"{number}. {item.Name}");
            }
            Console.WriteLine("Enter number of camera");
            int chosenNumber = 0;
            do
            {
                bool f = Int32.TryParse(Console.ReadLine(), out chosenNumber);
                if (f && chosenNumber > 0 && chosenNumber <= camerasInfo.Count)
                    break;
            }
            while (chosenNumber <= 0);
            VideoCaptureDevice webCam = new VideoCaptureDevice(camerasInfo[chosenNumber - 1].MonikerString);
            webCam.NewFrame += OnFrame;
            webCam.Start();
        }

        private static void OnFrame(object sender, NewFrameEventArgs e)
        {
            senderSocket.Send(e.Frame);
        }
    }
}
