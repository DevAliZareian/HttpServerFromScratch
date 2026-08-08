using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.Interfaces
{
    public interface IHttpServer
    {
        abstract static void Start(int port);
        abstract static void Stop();
        static bool IsRunning { get; private set; }
    }
}
