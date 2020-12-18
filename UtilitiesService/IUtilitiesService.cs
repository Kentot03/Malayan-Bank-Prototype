using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace UtilitiesService
{
    public interface IUtilitiesService
    {
        colResponse GetResponse(int code);
        string Create(colResponse model, ref int ReturnCode, ref String Exception, ref String StackTrace);
        bool Update(colResponse model, ref int ReturnCode, ref String Exception, ref String StackTrace);
        bool Delete(string id, ref int ReturnCode, ref String Exception, ref String StackTrace);
        colResponse ReadById(string id, ref int ReturnCode, ref String Exception, ref String StackTrace);

    }
}
