using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Service.Utiles.Bridges.ZipCodePerRadius
{
    public interface IZipRadiusService
    {
        Task<string[]> SearchByMileAsync(string sourceZip, int distance, string unites = "mile", string format = "json"/*json,xml,csv*/);
    }
}
