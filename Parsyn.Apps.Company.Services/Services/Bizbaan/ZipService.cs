using Microsoft.EntityFrameworkCore;
using Serilog;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Location;
using Parsyn.Apps.Company.Service.Utiles.Bridges.ZipCodePerRadius.Models;
using Parsyn.Apps.Company.Service.Utiles.Utiles;
using Parsyn.Apps.Company.Services.Interfaces.Bizbaan;
using Parsyn.Apps.Company.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Services.Bizbaan
{
    public class ZipService(PDBContext ctx, ILogger log) : BaseService<ZipModel>(ctx, log), IZipIface
    {
        public IEnumerable<ZipModel> GetLightPaged(int page, int size = 100)
        {
            var result = _dbObj.Select(x => new ZipModel()
            {
                Id = x.Id,
                Zipcode = x.Zipcode,
                County_Area = x.County_Area,
                State_Abbr = x.State_Abbr
            }).Page(page, size);
            return result.AsEnumerable();
        }

        public IEnumerable<ZipModel> GetLightPaged(int page, string q, int size = 100)
        {
            var result = _dbObj.Where(x => x.Zipcode.StartsWith(q) || x.Zipcode.EndsWith(q) ||
                                         EF.Functions.Like(x.County_Area.ToLower(), $"%{q.ToLower()}%") ||
                                         EF.Functions.Like(x.State.ToLower(), $"%{q.ToLower()}%") ||
                                         EF.Functions.Like(x.State_Abbr.ToLower(), $"%{q.ToLower()}%") ||
                                         EF.Functions.Like(x.City.ToLower(), $"%{q.ToLower()}%")).Select(x => new ZipModel()
                                         {
                                             Id = x.Id,
                                             Zipcode = x.Zipcode,
                                             County_Area = x.County_Area,
                                             State_Abbr = x.State_Abbr
                                         }).ToList().Page(page, size);
            return result.AsEnumerable();
        }
        public async Task<List<ZipModel>> GetZipCodesInRadius(double latitude, double longitude, double radius)
        {
            using (var command = _ctx.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "EXEC GetZipCodesInRadius @Latitude, @Longitude, @Radius";
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Latitude", latitude));
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Longitude", longitude));
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Radius", radius));

                await _ctx.Database.OpenConnectionAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    var results = new List<ZipModel>();
                    while (await reader.ReadAsync())
                    {
                        results.Add(new ZipModel
                        {
                            Latitude = (decimal)reader.GetDecimal(2),
                            Longitude = (decimal)reader.GetDecimal(3),
                            Distance = reader.GetDouble(4),
                            Zipcode = reader.GetString(1),
                            Id = reader.GetInt32(0)
                        });
                    }
                    return results;
                }
            }

        }
        public int GetPageCount()
        {
            var cnt = (float)_dbObj.Count();
            var pageCount = (int)Math.Ceiling((float)cnt / 100);
            return pageCount;
        }

        public ZipModel Find(string zipcode)
        {
            return _dbObj.FirstOrDefault(x => x.Zipcode == zipcode);
        }
    }
}
