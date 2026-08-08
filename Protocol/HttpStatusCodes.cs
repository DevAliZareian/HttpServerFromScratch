namespace HttpServer.Protocol
{
    public enum HttpStatusCodes
    {
        OK = 200,
        Created = 201,
        Accepted = 202,
        NoContent = 204,

        MovedPermanently = 301,
        Found = 302,
        NotModified = 304,

        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,

        InternalServerError = 500,
        NotImplemented = 501,
        BadGateway = 502,
        ServiceUnavailable = 503
    }

    public static class HttpStatusExtensions
    {
        public static string GetReasonPhrase(this HttpStatusCodes status)
        {
            return status switch
            {
                HttpStatusCodes.OK => "OK",
                HttpStatusCodes.Created => "Created",
                HttpStatusCodes.Accepted => "Accepted",
                HttpStatusCodes.NoContent => "No Content",
                HttpStatusCodes.MovedPermanently => "Moved Permanently",
                HttpStatusCodes.Found => "Found",
                HttpStatusCodes.NotModified => "Not Modified",
                HttpStatusCodes.BadRequest => "Bad Request",
                HttpStatusCodes.Unauthorized => "Unauthorized",
                HttpStatusCodes.Forbidden => "Forbidden",
                HttpStatusCodes.NotFound => "Not Found",
                HttpStatusCodes.MethodNotAllowed => "Method Not Allowed",
                HttpStatusCodes.InternalServerError => "Internal Server Error",
                HttpStatusCodes.NotImplemented => "Not Implemented",
                HttpStatusCodes.BadGateway => "Bad Gateway",
                HttpStatusCodes.ServiceUnavailable => "Service Unavailable",
                _ => "Unknown"
            };
        }
    }
}