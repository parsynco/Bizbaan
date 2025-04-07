using Parsyn.Apps.Company.Data.Models.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity
{
    public class OptionsModel:BaseModel
    {
        public string? Key {  get; set; }
        public string? Value {  get; set; }
    }
}
