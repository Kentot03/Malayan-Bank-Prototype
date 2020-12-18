using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientLogsService
{
    public interface IClientLogs
    {
        Task<ServiceResponse<string>> Create(clientlogs model);
        Task<ServiceResponse<bool>> Update(clientlogs model);
        Task<ServiceResponse<bool>> Delete(string id);
        Task<ServiceResponse<List<clientlogs>>> ReadAll();
        Task<ServiceResponse<clientlogs>> ReadById(string id);
    }
}
