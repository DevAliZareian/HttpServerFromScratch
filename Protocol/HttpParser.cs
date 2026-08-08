using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.Protocol
{
    public static class HttpParser
    {
        public static HttpRequest Parse(string request)
        {
            var httpRequest = new HttpRequest();

            var lines = request.Split(["\r\n", "\n"], StringSplitOptions.None);

            if (lines.Length < 0 )
            {
                return httpRequest;
            }

            var requestLine = lines[0].Split(" ");
            if (requestLine.Length >= 3)
            {
                httpRequest.Method = requestLine[0];
                httpRequest.Path = requestLine[1];
                httpRequest.Version = requestLine[2];
            }

            var headersEndIndex = -1;
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    headersEndIndex = i;
                    break;
                }

                var headerParts = lines[i].Split([':'], 2);
                if (headerParts.Length == 2)
                {
                    var key = headerParts[0].Trim();
                    var value = headerParts[1].Trim();
                    httpRequest.Headers[key] = value;
                }
            }

            if (headersEndIndex >= 0 && headersEndIndex < lines.Length - 1)
            {
                var bodyLines = new List<string>();
                for (int i = headersEndIndex + 1; i < lines.Length; i++)
                {
                    bodyLines.Add(lines[i]);
                }
                httpRequest.Body = string.Join("\n", bodyLines);
            }

            return httpRequest;
        }
    }
}
