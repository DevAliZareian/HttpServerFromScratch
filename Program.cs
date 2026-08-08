using HttpServer.Configuration;
using HttpServer.Core;

namespace HttpServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "--secret-key" && i + 1 < args.Length)
                {
                    ServerConfiguration.SecretKey = args[i + 1];
                }

                if (args[i] == "--port" && i + 1 < args.Length)
                {
                    if (int.TryParse(args[i + 1], out int port))
                    {
                        Server.Start(port);
                    }
                    else
                    {
                        Console.WriteLine("Invalid port number.");
                    }
                }
            }
        }
    }
}
