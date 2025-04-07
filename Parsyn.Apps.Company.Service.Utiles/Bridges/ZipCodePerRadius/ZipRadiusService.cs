using Microsoft.Extensions.Configuration;
using Parsyn.Apps.Company.Service.Utiles.Bridges.ZipCodePerRadius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Service.Utiles.Bridges.ZipCodePerRadius
{
    public class ZipRadiusService : IZipRadiusService
    {
        private readonly IConfiguration _config;
        private string _ApiKey {  get; set; }
        private readonly HttpClient _httpClient;
        public ZipRadiusService(IConfiguration configuration)
        {
            _config = configuration;
            _ApiKey = _config["ZipApiKey"] ?? throw new Exception("ZipApiKey not found.");
            _httpClient = new HttpClient();
            _configHttpClient();
        }
        private void _configHttpClient()
        {
            _httpClient.BaseAddress = new Uri($"https://www.zipcodeapi.com/rest/{_ApiKey}/");
        }
        public async Task<string[]> SearchByMileAsync(string sourceZip, int distance,string unites = "mile", string format = "json"/*json,xml,csv*/)
        {
            var result =await _httpClient.GetFromJsonAsync<ZipResponseDto>($"radius.{format}/{sourceZip}/{distance}/{unites}");
            if(result is not null && result.zip_codes is not null && result.zip_codes.Count > 1)
            {
                return [.. result.zip_codes.Select(x => x.zip_code)];
            }
            return [];
        }
    }
}
