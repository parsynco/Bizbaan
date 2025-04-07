using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects
{
    public class ResponseObject
    {
        public ResponseObjectStatusEnum Status { get; set; }
        public string? Msg { get; set; }
        public object? Data { get; set; }
        public object? AdditionalData { get; set; }
    }
    public enum ResponseObjectStatusEnum
    {
        Success = 0, Error = 1, UnhandeledException = 2
    }
}
