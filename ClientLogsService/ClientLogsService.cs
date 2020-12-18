using DataAccess.DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ClientLogsService
{
    public class ClientLogsService : IClientLogs
    {
        public async Task<ServiceResponse<string>> Create(clientlogs model)
        {
            ServiceResponse<string> serviceResponse = new ServiceResponse<string>();
            try
            {
                serviceResponse.Details = await ClientLogsDAL.Create(model);
            }
            catch (Exception ex)
            {
                if (!Helpers.isNumber(ex.Message))
                {
                    serviceResponse.ReturnCode = 500;
                    serviceResponse.Exception = ex.Message;
                    serviceResponse.StackTrace = ex.StackTrace.ToString();
                }
                else
                {
                    serviceResponse.ReturnCode = Convert.ToInt32(ex.Message);
                }

                return serviceResponse;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> Delete(string id)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();
            try
            {
                serviceResponse.Details = await ClientLogsDAL.Delete(id);

            }
            catch (Exception ex)
            {
                if (!Helpers.isNumber(ex.Message))
                {
                    serviceResponse.ReturnCode = 500;
                    serviceResponse.Exception = ex.Message;
                    serviceResponse.StackTrace = ex.StackTrace.ToString();
                }
                else
                {
                    serviceResponse.ReturnCode = Convert.ToInt32(ex.Message);
                }
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> Update([FromBody]clientlogs model)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();
            try
            {
                serviceResponse.Details = await ClientLogsDAL.Update(model);

            }
            catch (Exception ex)
            {
                if (!Helpers.isNumber(ex.Message))
                {
                    serviceResponse.ReturnCode = 500;
                    serviceResponse.Exception = ex.Message;
                    serviceResponse.StackTrace = ex.StackTrace.ToString();
                }
                else
                {
                    serviceResponse.ReturnCode = Convert.ToInt32(ex.Message);
                }


                return serviceResponse;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<clientlogs>>> ReadAll()
        {
            ServiceResponse<List<clientlogs>> serviceResponse = new ServiceResponse<List<clientlogs>>();
            try
            {
                serviceResponse.Details = await ClientLogsDAL.ReadAll();
            }
            catch (Exception ex)
            {
                if (!Helpers.isNumber(ex.Message))
                {
                    serviceResponse.ReturnCode = 500;
                    serviceResponse.Exception = ex.Message;
                    serviceResponse.StackTrace = ex.StackTrace.ToString();
                }
                else
                {
                    serviceResponse.ReturnCode = Convert.ToInt32(ex.Message);
                }
                return serviceResponse;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<clientlogs>> ReadById(string id)
        {
            ServiceResponse<clientlogs> serviceResponse = new ServiceResponse<clientlogs>();
            try
            {
                serviceResponse.Details = await ClientLogsDAL.ReadById(id);
                return serviceResponse;
            }
            catch (Exception ex)
            {
                if (!Helpers.isNumber(ex.Message))
                {
                    serviceResponse.ReturnCode = 500;
                    serviceResponse.Exception = ex.Message;
                    serviceResponse.StackTrace = ex.StackTrace.ToString();
                }
                else
                {
                    serviceResponse.ReturnCode = Convert.ToInt32(ex.Message);
                }

                return serviceResponse;
            }
        }
    }
}
