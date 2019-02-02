using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //IPHostEntry hostEntry = Dns.GetHostEntry("localhost");
            //IPAddress address = IPAddress.Parse("192.168.56.1");

            //IPEndPoint endPoint = new IPEndPoint(address, 23456);

            //Socket socket = new Socket(address.AddressFamily,
            //                           SocketType.Stream,
            //                           ProtocolType.Tcp);

            //socket.Connect(endPoint);
            //Console.WriteLine("Connecting ...");

            //Console.WriteLine("Input message: ");
            //string message = Console.ReadLine();

            //byte[] data = Encoding.UTF8.GetBytes(message + "<End>");

            //int sendBytes = socket.Send(data);

            //byte[] dataRecive = new byte[1024];
            //int reciveBytes = socket.Receive(dataRecive);

            //Console.WriteLine("Answer: {0}",
            //    Encoding.UTF8.GetString(dataRecive, 0, reciveBytes));

            //socket.Shutdown(SocketShutdown.Both);
            //socket.Close();

            IPAddress address = IPAddress.Parse("localhost");

            //IPEndPoint endPoint = new IPEndPoint(address, 23456);

            Socket socket = new Socket(address.AddressFamily,
                                       SocketType.Dgram,
                                       ProtocolType.Udp);

            //socket.Connect(endPoint);
            Console.WriteLine("Connecting ...");

            socket.Bind(new IPEndPoint(address, 23456));

            Console.WriteLine("Input message: ");
            string message = Console.ReadLine();

            byte[] data = Encoding.UTF8.GetBytes(message + "<End>");

            int sendBytes = socket.SendTo(data, new IPEndPoint(address, 23456));


            byte[] dataRecive = new byte[1024];
            EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            int reciveBytes = socket.ReceiveFrom(dataRecive, ref endPoint);

            Console.WriteLine("Answer: {0}",
                Encoding.UTF8.GetString(dataRecive, 0, reciveBytes));

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();


        }
    }
}
