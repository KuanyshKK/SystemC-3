using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //IPHostEntry hostEntry = Dns.GetHostEntry("localhost");
            //IPAddress address = hostEntry.AddressList[1];

            //IPEndPoint endPoint = new IPEndPoint(address, 23456);

            //Socket socket = new Socket(address.AddressFamily,
            //                           SocketType.Stream,
            //                           ProtocolType.Tcp);

            //try
            //{
            //    socket.Bind(endPoint);
            //    socket.Listen(5);
            //    int marker = 0;

            //    while(true)
            //    {
            //        Console.WriteLine("Listening ...");

            //        Socket acceptSocket = socket.Accept();

            //        StringBuilder stringBuilder = new StringBuilder();

            //        byte[] bytes;
            //        int byteRec;

            //        while (true)
            //        {
            //            bytes = new byte[1024];
            //            byteRec = acceptSocket.Receive(bytes);
            //            stringBuilder.Append(Encoding.UTF8.GetString(bytes));

            //            marker = stringBuilder.ToString().LastIndexOf("<End>");

            //            if (marker >= 1)
            //                break;
            //        }

            //        Console.WriteLine("Message: {0}", 
            //            stringBuilder.ToString().Substring(0,marker));

            //        string answer = string.Format("Thanks received {0} bytes received.",
            //            stringBuilder.Length);
            //        byte[] reciveMsg = Encoding.UTF8.GetBytes(answer);

            //        acceptSocket.Send(reciveMsg);
            //        acceptSocket.Shutdown(SocketShutdown.Both);
            //        acceptSocket.Close();


            //    }
            //}
            //catch(Exception)
            //{
            //    throw;
            //}

            IPHostEntry hostEntry = Dns.GetHostEntry("localhost");
            IPAddress address = hostEntry.AddressList[1];

            IPEndPoint endPoint = new IPEndPoint(address, 23456);

            Socket socket = new Socket(address.AddressFamily,
                                       SocketType.Dgram,
                                       ProtocolType.Udp);
            socket.Bind(endPoint);
            Console.WriteLine("Waiting ...");
            byte[] bytes = new byte[1024];
            EndPoint endPointRecieve = new IPEndPoint(IPAddress.Any, 0);
            int byteRec = socket.ReceiveFrom(bytes, ref endPointRecieve);

            Console.WriteLine("Recieved from {0}: \n\n",
                (endPointRecieve as IPEndPoint).Address,
                Encoding.UTF8.GetString(bytes, 0, byteRec));

            socket.SendTo(Encoding.UTF8.GetBytes("Hello UDP"), endPointRecieve as IPEndPoint);
           
        }
    }
}
