using HttpServer.Interfaces;
using HttpServer.Utils;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace HttpServer.Core
{
    public class Server : IHttpServer
    {
        public static bool IsRunning { get; private set; }

        public static void Start(int port)
        {
            IsRunning = true;

            try
            {
                Logger.Info($"Starting server on {port}");

                var socket = new SocketHandler(port);
                socket.Run();
            }
            catch (SocketException ex)
            {
                Logger.Error($"Socket error: {ex.Message}");
                Logger.Error($"Error code: {ex.ErrorCode}");

                if (ex.ErrorCode == 10048)
                {
                    Logger.Error($"Port {port} is already in use. Choose a different port.");
                }
                else if (ex.ErrorCode == 10013)
                {
                    Logger.Error($"Access denied. Try running as administrator.");
                }

                throw;
            }
            catch (Exception ex)
            {
                Logger.Error($"Fatal server error: {ex.Message}");
                Logger.Error($"Stack trace: {ex.StackTrace}");

                throw;
            }
            finally
            {
                Logger.Info("Server shutting down...");
                IsRunning = false;
            }
        }

        public static void Stop()
        {
            Logger.Info("Server stop requested");
            IsRunning = false;
        }
    }
}
