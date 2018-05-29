using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conference
{
    class Program
    {
        static void Main(string[] args)
        {
            IServer server = new ConsoleServer();
            server.Run();
        }
    }
}
