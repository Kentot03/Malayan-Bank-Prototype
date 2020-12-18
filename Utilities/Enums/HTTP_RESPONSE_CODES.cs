using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utilities.Enums
{
    public class HTTP_RESPONSE_CODES
    {
        public Dictionary<int, string> codes { get; set; } = new Dictionary<int, string>
        {
            { 200, "Request successfully processed"},
            { 201, "Record successfully created"},
            { 401, "Unauthorized: Access to this resource is denied"},
            { 409, "Record already exists" },
            { 500, "An error has been encountered"}
        };
    }
}
