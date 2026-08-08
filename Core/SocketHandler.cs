using System.Net.Sockets;
using System.Net;
using HttpServer.Utils;
using System.Linq.Expressions;

namespace HttpServer.Core
{
    public class SocketHandler
    {
        private readonly Socket _listenerSocket;
        private readonly int _port;
        private bool _isRunning;

        public SocketHandler(int port)
        {
            _port = port;
            _listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Run()
        {
            OpenPort(_port);

            _listenerSocket.Bind(new IPEndPoint(IPAddress.Any, _port));
            _listenerSocket.Listen(10);
            _isRunning = true;

            Console.WriteLine($"Server started on {IPAddress.Any}:{_port}. Waiting for connections...");

            while (_isRunning)
            {
                Socket client = _listenerSocket.Accept();
                HandleClient(client);
            }
        }

        public void Stop()
        {
            _isRunning = false;
            _listenerSocket.Close();
            Console.WriteLine("Server stopped.");
        }

        private static void HandleClient(Socket client)
        {
            try
            {
                byte[] buffer = new byte[1024];

                int receivedBytes = client.Receive(buffer);
                string request = System.Text.Encoding.UTF8.GetString(buffer, 0, receivedBytes);

                Console.WriteLine(request);

                if (request.StartsWith("GET"))
                {
                    string response = "HTTP/1.1 200 OK\r\nContent-Type: text/plain\r\n\r\nAmooByco Eshgh!";
                    byte[] responseBytes = System.Text.Encoding.UTF8.GetBytes(response);
                    client.Send(responseBytes);
                }
                else
                {
                    string response = "HTTP/1.1 400 Bad Request\r\nContent-Type: text/plain\r\n\r\nBad Request";
                    byte[] responseBytes = System.Text.Encoding.UTF8.GetBytes(response);
                    client.Send(responseBytes);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error handling client: {ex.Message}");
            }
            finally
            {
                client.Close();
            }
        }

        private static bool OpenPort(int port)
        {
            try
            {
                Cmd.Execute($"netsh advfirewall firewall add rule name=\"Open Port {port}\" dir=in action=allow protocol=TCP localport={port}");
                return true;
            }
            catch
            {
                Console.WriteLine($"Failed to open port {port}. You may need admin privileges.");
                return false;
            }
        }
    }
}
