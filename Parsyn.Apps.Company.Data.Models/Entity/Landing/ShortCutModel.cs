using Parsyn.Apps.Company.Data.Models.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.Landing
{
    public class ShortCutModel:BaseModel
    {
        public string? Title {  get; set; }
        public string? Description {  get; set; }
        public string? BtnTitle1 {  get; set; }
        public string? BtnTitle2 {  get; set; }
        public string? Link1 {  get; set; }
        public string? Link2 {  get; set; }
    }
}
