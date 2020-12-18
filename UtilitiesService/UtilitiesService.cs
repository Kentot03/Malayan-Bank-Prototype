using DataAccess.DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Utilities.Enums;

namespace UtilitiesService
{
    public class UtilitiesService : IUtilitiesService
    {
        public colResponse GetResponse(int code)
        {
            var result = ResponseDal.Read().Where(x => x.code == code).FirstOrDefault();
            return result;
        }
        public string Create(colResponse model, ref int ReturnCode, ref String Exception, ref String StackTrace)
        {
            try
            {
                var isExists = ResponseDal.Read().Any(x => x.code == model.code);
                if (!isExists)
                    return ResponseDal.Create(model);
                else
                {
                    ReturnCode = 409;

                    return String.Empty;
                }
            }
            catch (Exception ex)
            {
                if (!Helpers.isNumber(ex.Message))
                {
                    ReturnCode = 500;
                    Exception = ex.Message;
                    StackTrace = ex.StackTrace.ToString();
                }
                else
                {
                    ReturnCode = Convert.ToInt32(ex.Message);
                }

                return ex.Message;
            }
        }

        public bool Delete(string id, ref int ReturnCode, ref String Exception, ref String StackTrace)
        {
            try
            {
                return ResponseDal.Delete(id);
            }
            catch (Exception ex)
            {
                if (!Helpers.isNumber(ex.Message))
                {
                    ReturnCode = 500;
                    Exception = ex.Message;
                    StackTrace = ex.StackTrace.ToString();
                }
                else
                {
                    ReturnCode = Convert.ToInt32(ex.Message);
                }

                return false;
            }
        }

        public bool Update(colResponse model, ref int ReturnCode, ref String Exception, ref String StackTrace)
        {
            try
            {
                return ResponseDal.Update(model);
            }
            catch (Exception ex)
            {
                if (!Helpers.isNumber(ex.Message))
                {
                    ReturnCode = 500;
                    Exception = ex.Message;
                    StackTrace = ex.StackTrace.ToString();
                }
                else
                {
                    ReturnCode = Convert.ToInt32(ex.Message);
                }

                return false;
            }
        }

        public colResponse ReadById(string id, ref int ReturnCode, ref String Exception, ref String StackTrace)
        {
            colResponse result = new colResponse();
            try
            {
                result = ResponseDal.Read().Where(x => x._id == id).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                if (!Helpers.isNumber(ex.Message))
                {
                    ReturnCode = 500;
                    Exception = ex.Message;
                    StackTrace = ex.StackTrace.ToString();
                }
                else
                {
                    ReturnCode = Convert.ToInt32(ex.Message);
                }

                return result;
            }
        }
    }
}
