using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Service.Utiles.Bridges.ZipCodePerRadius.Models
{
    public class ZipResponseDto
    {
        public List<ZipResponseModel>? zip_codes { get; set; }
    }
    public class ZipResponseModel
    {
        public string? zip_code {  get; set; }
        public decimal? distance {  get; set; }
        public string? city {  get; set; }
        public string? state {  get; set; }
    }
    
}
