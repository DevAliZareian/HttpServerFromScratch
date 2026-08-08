using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.Protocol
{
    public class HttpResponse
    {
        private readonly string _version;
        private readonly int _statusCode;
        private readonly string _statusText;
        private readonly string _content;
        private readonly int _contentLength;
        private readonly Dictionary<string, string> _headers;

        public HttpResponse(HttpStatusCodes statusCode, string content, string contentType)
        {
            _version = HttpProtocolVersion.Default;
            _statusCode = (int)statusCode;
            _statusText = statusCode.GetReasonPhrase();
            _content = content;
            _contentLength = Encoding.UTF8.GetByteCount(content);

            _headers = new Dictionary<string, string>
            {
                ["Content-Type"] = contentType,
                ["Content-Length"] = _contentLength.ToString()
            };
        }

        public byte[] ToBytes()
        {
            var sb = new StringBuilder();

            sb.Append($"{_version} {_statusCode} {_statusText}\r\n");

            foreach (var header in _headers)
            {
                sb.Append($"{header.Key}: {header.Value}\r\n");
            }

            sb.Append("\r\n");
            sb.Append(_content);

            return Encoding.UTF8.GetBytes(sb.ToString());
        }
    }
}