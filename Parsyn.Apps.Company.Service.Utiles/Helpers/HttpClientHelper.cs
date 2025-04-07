using Newtonsoft.Json;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using Parysn.Apps.Company.Service.Utiles.ShareMemmory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Service.Utiles.Helpers
{
    public class HttpClientHelper<T> where T : class
    {
        private RespGeneratorSrvc _respsrvc;
        private   string _BaseUrl {  get; set; }
        private HttpClient _hc;
        public  HttpClientHelper(string url)
        {
            _BaseUrl = url;
            _hc = new HttpClient
            {
                BaseAddress = new Uri(_BaseUrl)
            };
            _respsrvc = new RespGeneratorSrvc();
        }
        public HttpClient Instance()
        {
            //CheckToken();
            return _hc;
        }
        public async Task<ResponseObject> Post(T model,string url)
        {
            //CheckToken();
            var result = await _hc.PostAsJsonAsync(url, model);
            return await _readResponse(result);
            
        }
        public async Task<ResponseObject> Post(object param, string url)
        {
            //CheckToken();
            var result = await _hc.PostAsJsonAsync(url, param);
            return await _readResponse(result);

        }
        public void SetToken(string token)
        {
            _hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        private void CheckToken()
        {
            if (!string.IsNullOrEmpty(GlobalShare.GetToken()))
            {
                _hc.DefaultRequestHeaders.Authorization =  new AuthenticationHeaderValue("Bearer", GlobalShare.GetToken());
            }
        }
        private  async Task<ResponseObject> _readResponse(HttpResponseMessage hrm)
        {
            if (hrm is null)
                return _respsrvc.MapError("در حال حاضر امکان ارتباط با سرور وجود ندارد.");
        
            if(hrm.IsSuccessStatusCode)
            {
                var converted = await hrm.Content.ReadFromJsonAsync<ResponseObject>();
               return converted;

            }
            else
            {
                return _respsrvc.MapError("در حال حاضر امکان ارتباط با سرور وجود ندارد.",hrm.StatusCode);
            }
        }

    }
}
