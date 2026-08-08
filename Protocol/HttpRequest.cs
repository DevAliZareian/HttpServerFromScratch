namespace HttpServer.Protocol
{
    public class HttpRequest
    {
        public string Method { get; set; } = "GET";
        public string Path { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        public string Body { get; set; } = string.Empty;
    }
}
