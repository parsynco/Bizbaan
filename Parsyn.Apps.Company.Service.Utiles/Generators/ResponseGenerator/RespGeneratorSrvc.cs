using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator
{
    public class RespGeneratorSrvc
    {
        public  ResponseObject MapOk(string msg = "عملیات موفق",object? data = null,object additionalData = null)
        {
            return new ResponseObject()
            {
                Status = ResponseObjectStatusEnum.Success,
                AdditionalData = additionalData,
                Data = data,
                Msg = msg
            };
        }
        public  ResponseObject MapError(string msg = "عملیات ناموفق", object? data = null, object additionalData = null)
        {
            return new ResponseObject()
            {
                Status = ResponseObjectStatusEnum.Error,
                AdditionalData = additionalData,
                Data = data,
                Msg = msg
            };
        }
        public  ResponseObject MapUnhandeled(string msg = "خطای داخلی سرور", object? data = null, object additionalData = null)
        {
            return new ResponseObject()
            {
                Status = ResponseObjectStatusEnum.UnhandeledException,
                AdditionalData = additionalData,
                Data = data,
                Msg = msg
            };
        }

       
    }
}
