namespace HttpServer.Protocol
{
    public static class HttpProtocolVersion
    {
        public const string Http10 = "HTTP/1.0";
        public const string Http11 = "HTTP/1.1";
        public const string Http20 = "HTTP/2.0";
        public const string Default = Http11;

        public static bool IsValid(string version)
        {
            return version == Http10 ||
                   version == Http11 ||
                   version == Http20;
        }
    }
}