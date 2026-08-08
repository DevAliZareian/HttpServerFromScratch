namespace HttpServer.Protocol
{
    public static class ContentTypes
    {
        public const string TextPlain = "text/plain";
        public const string TextHtml = "text/html";
        public const string TextCss = "text/css";
        public const string TextJavascript = "text/javascript";

        public const string ApplicationJson = "application/json";
        public const string ApplicationXml = "application/xml";
        public const string ApplicationJavascript = "application/javascript";
        public const string ApplicationOctetStream = "application/octet-stream";
        public const string ApplicationPdf = "application/pdf";
        public const string ApplicationZip = "application/zip";

        public const string ImageJpeg = "image/jpeg";
        public const string ImagePng = "image/png";
        public const string ImageGif = "image/gif";
        public const string ImageSvg = "image/svg+xml";

        public static string GetForExtension(string extension)
        {
            return extension.ToLower() switch
            {
                ".txt" => TextPlain,
                ".html" or ".htm" => TextHtml,
                ".css" => TextCss,
                ".js" => TextJavascript,
                ".json" => ApplicationJson,
                ".xml" => ApplicationXml,
                ".pdf" => ApplicationPdf,
                ".zip" => ApplicationZip,
                ".jpg" or ".jpeg" => ImageJpeg,
                ".png" => ImagePng,
                ".gif" => ImageGif,
                ".svg" => ImageSvg,
                _ => ApplicationOctetStream
            };
        }
    }
}