using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Utilities.Enums
{
    public enum HTTP_RESPONSE_CODE_OLD
    {
        // 1xx codes = Informational
        Continue = 100,
        SwitchingProtocols = 101,

        // 2xx codes = Successful
        [Description("Successful")]
        OK = 200,
        [Description("Created")]
        Created = 201,
        [Description("Accepted")]
        Accepted = 202,
        NonAuthoritativeInformation = 203,
        NoContent = 204,
        ResetContent = 205,
        PartialContent = 206,

        // 3xx codes = Redirection
        MultipleChoices = 300,
        MovedPermanently = 301,
        Found = 302,
        SeeOther = 303,
        NotModified = 304,
        UseProxy = 305,
        Unused = 306,
        TemporaryRedirect = 307,

        // 4xx codes = Client Error
        [Description("Bad Request")]
        BadRequest = 400,
        [Description("Unauthorized")]
        Unauthorized = 401,
        PaymentRequired = 402,
        [Description("Forbidden")]
        Forbidden = 403,
        [Description("Not Fount")]
        NotFound = 404,
        [Description("Method Not Allowed")]
        MethodNotAllowed = 405,
        [Description("Not Acceptable")]
        NotAcceptable = 406,
        ProxyAuthenticationRequired = 407,
        [Description("Request Timeout")]
        RequestTimeout = 408,
        Conflict = 409,
        Gone = 410,
        LengthRequired = 411,
        PreconditionFailed = 412,
        RequestEntityTooLarge = 413,
        RequestUriTooLong = 414,
        [Description("Unsupported Media Type")]
        UnsupportedMediaType = 415,
        RequestedRangeNotSatisfiable = 416,
        ExpectationFailed = 417,

        // 5xx codes = Server Error
        [Description("Internal Server Error")]
        InternalServerError = 500,
        [Description("Not Implemented")]
        NotImplemented = 501,
        [Description("Bad Gateway")]
        BadGateway = 502,
        [Description("Service Unavailable")]
        ServiceUnavailable = 503,
        [Description("Gateway Timeout")]
        GatewayTimeout = 504,
        HttpVersionNotSupported = 505
    }
}
