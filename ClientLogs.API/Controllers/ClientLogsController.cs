using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientLogsService;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ClientLogs.API.Controllers.ClientLogs
{
    [Route("api/clientlogs")]
    [ApiController]
    public class ClientLogsController : BaseController
    {
        private IClientLogs iclientLogs;
        public ClientLogsController(IClientLogs _iclientLogs)
        {
            this.iclientLogs = _iclientLogs;
        }

        [HttpPost("~/api/clientlogs")]
        public async Task<Response<string>> Create([FromBody]clientlogs model)
        {
            var response = new Response<String>();
            try
            {
                var serviceResponse = await iclientLogs.Create(model);
                response.Details = serviceResponse.Details;
                response.Code = returnCode;
                response.Message = MapErrorMsg(returnCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        [HttpPut("~/api/clientlogs")]
        public async Task<Response<bool>> Update([FromBody]clientlogs model)
        {
            var response = new Response<bool>();
            try
            {
                var serviceResponse = await iclientLogs.Update(model);
                response.Details = serviceResponse.Details;
                response.Code = returnCode;
                response.Message = MapErrorMsg(returnCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        [HttpDelete("~/api/clientlogs/{id}")]
        public async Task<Response<bool>> Delete(string id)
        {
            var response = new Response<bool>();
            try
            {
                var serviceResponse = await iclientLogs.Delete(id);
                response.Details = serviceResponse.Details;
                response.Code = returnCode;
                response.Message = MapErrorMsg(returnCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        [HttpGet("~/api/clientlogs")]
        public async Task<Response<List<clientlogs>>> ReadAll()
        {
            var response = new Response<List<clientlogs>>();
            var serviceResponse = await iclientLogs.ReadAll();
            response.Details = serviceResponse.Details;
            response.Code = returnCode;
            response.Message = MapErrorMsg(returnCode);

            return response;
        }

        [HttpGet("~/api/clientlogs/{id}")]
        public async Task<Response<clientlogs>> ReadById(string id)
        {
            var response = new Response<clientlogs>();
            try
            {
                var serviceResponse = await iclientLogs.ReadById(id);
                response.Details = serviceResponse.Details;
                response.Code = returnCode;
                response.Message = MapErrorMsg(returnCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }
    }
}