using System.Net;

namespace WeStock.App
{
    public class HttpErrorMessages
    {
        public static string HttpStatusNotFound = "Http status {0} not found";

        public static Dictionary<HttpStatusCode, string> Messages = new Dictionary<HttpStatusCode, string>
        {
            { HttpStatusCode.BadRequest, "Bad request" },
            { HttpStatusCode.Unauthorized, "Not authorized" },
            { HttpStatusCode.Forbidden, "Forbidden" },
            { HttpStatusCode.NotFound, "Not found" },
            { HttpStatusCode.MethodNotAllowed, "Method not allowed" },
            { HttpStatusCode.NotAcceptable, "Not acceptable" },
            { HttpStatusCode.ProxyAuthenticationRequired, "Proxy authentication required" },
            { HttpStatusCode.RequestTimeout, "Request timeout" },
            { HttpStatusCode.Conflict, "Conflict" },
            { HttpStatusCode.Gone, "No longer available" },
            { HttpStatusCode.LengthRequired, "Content-length header required" },
            { HttpStatusCode.PreconditionFailed, "Pre-condition failed" },
            { HttpStatusCode.RequestEntityTooLarge, "Request entity too large" },
            { HttpStatusCode.RequestUriTooLong, "Request uri too long" },
            { HttpStatusCode.UnsupportedMediaType, "Unsupported media type" },
            { HttpStatusCode.RequestedRangeNotSatisfiable, "Requested range not satisfiable" },
            { HttpStatusCode.ExpectationFailed, "Expectation failed" },
            { HttpStatusCode.InternalServerError, "Internal server error" },
            { HttpStatusCode.NotImplemented, "Not implemented" },
            { HttpStatusCode.BadGateway, "Bad gateway" },
            { HttpStatusCode.ServiceUnavailable, "Service unavailable" },
            { HttpStatusCode.GatewayTimeout, "Gateway timeout" },
            { HttpStatusCode.HttpVersionNotSupported, "Http version not supported" },
        };
    }
}