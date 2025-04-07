using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Dtos.Base.IndexSections
{
    public class Sec2Dto
    {
        public string? Image {  get; set; }
        public string? Description { get; set; }
        public List<Sec2Dto_sub>? Collections { get; set; }
    }
    public class Sec2Dto_sub {
        public string? Icon {  get; set; }
        public string? Title { get; set; }
        public string? Color {  get; set; }
    }
}
