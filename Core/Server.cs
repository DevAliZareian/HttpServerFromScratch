using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.Core
{
    public class Server
    {
        public static void Start(int port)
        {
			try
			{
				var socket = new SocketHandler(port);
                socket.Run();
            }
			catch (Exception)
			{
                // TODO: Handle the Whole Sever Errors.
				throw;
			}
        }
    }
}
