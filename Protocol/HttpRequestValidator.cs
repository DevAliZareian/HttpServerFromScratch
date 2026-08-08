using HttpServer.Configuration;
using HttpServer.Utils;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace HttpServer.Protocol
{
    public class HttpRequestValidator
    {
        private readonly HttpRequest _request;
        private readonly Socket _client;

        public HttpRequestValidator(HttpRequest request, Socket client)
        {
            _request = request;
            _client = client;
        }

        private bool HttpMethodIsValid()
        {
            if (Enum.IsDefined(typeof(HttpMethodTypes), _request.Method))
            {
                return true;
            }

            Logger.Warning("Method is wrong!", _client?.RemoteEndPoint?.ToString());
            return false;
        }

        private bool SecretKeyIsValid()
        {
            if (!String.IsNullOrEmpty(ServerConfiguration.SecretKey))
            {
                if (_request.Headers["Secret-Key"] == ServerConfiguration.SecretKey)
                {
                    return true;
                }

                Logger.Error("Access denied.", _client?.RemoteEndPoint?.ToString());
                return false;
            }

            return true;
        }

        public bool IsValid()
        {
            if (HttpMethodIsValid() && SecretKeyIsValid()) return true;
            return false;
        }
    }
}
