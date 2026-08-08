using HttpServer.Protocol;
using HttpServer.Utils;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace HttpServer.Handlers
{
    public static class RequestHandler
    {
        public static void Handle(HttpRequest request, Socket client)
        {
            var validator = new HttpRequestValidator(request, client);

            if (validator.IsValid())
            {
                string content = PathFinder.Find<string>(request.Path);
                var response = new HttpResponse(HttpStatusCodes.OK, content, HttpContentTypes.GetForExtension("." + request.Path.Split(".")[1]));
                byte[] responseBytes = response.ToBytes();
                client.Send(responseBytes);
            }
        }
    }
}
