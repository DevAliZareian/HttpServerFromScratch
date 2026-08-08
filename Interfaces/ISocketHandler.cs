using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.Interfaces
{
    public interface ISocketHandler
    {
        void Run();
        void Stop();
    }
}
