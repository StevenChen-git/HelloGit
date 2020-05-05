using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class TcpClient
{
    public static void Main(string[] args)
    {
        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(args[0]), 20);

        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        server.Connect(ipep);

        while(true)
        {
         string input = Console.ReadLine();
         if (input == "exit")
         break;
         byte[] data = Encoding.UTF8.GetBytes(input);
//     byte[] data = Encoding.ASCII.GetBytes(input);
         server.Send(data);
        }
        Console.WriteLine("Disconnecting from server...");
        server.Shutdown(SocketShutdown.Both);
        server.Close();
    }
}