using System;
using Microsoft.AspNetCore.Mvc;
using Utilities.Enums;
using Utilities.Core;

namespace ClientLogs.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected internal string exception = string.Empty;
        protected internal string stackTrace = string.Empty;
        protected internal int returnCode = 200;
        protected internal string systemID = string.Empty;
        protected internal HTTP_RESPONSE_CODES _http_response_codes;
        public BaseController()
        {
            _http_response_codes = new HTTP_RESPONSE_CODES();
        }

        [NonAction]
        protected internal string MapErrorMsg(int code)
        {
            try
            {
                _http_response_codes.codes.TryGetValue(returnCode, out var message);
                return message;
            }
            catch (Exception)
            {
                return INV_MSG.SERVER_ERROR.GetDescription();
            }
        }
    }
}