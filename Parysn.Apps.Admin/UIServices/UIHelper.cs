using MudBlazor;
using Parsyn.Apps.Company.Data.Models.Dtos.UIDtos;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using System.Diagnostics;

namespace Parysn.Apps.Admin.UIServices
{
    public interface IUIHelper
    {
        string ApiUrl();
        ResponseObjectStatusEnum HandleResponse(ResponseObject rsp, ISnackbar snackbar);
    }
    public class UIHelper : IUIHelper
    {
        public string BaseUrl { get; set; }
        private readonly IConfiguration _conf;
        public UIHelper(IConfiguration conf)
        {
            _conf = conf;
            BaseUrl = _conf["API_URL"];
        }
        public string ApiUrl()
        {
            var url = $"{BaseUrl}/api/admin/";
            return url;
        }
        public ResponseObjectStatusEnum HandleResponse(ResponseObject rsp, ISnackbar snackbar)
        {
            if (rsp.Status == ResponseObjectStatusEnum.Error || rsp.Status == ResponseObjectStatusEnum.UnhandeledException)
            { snackbar.Add(rsp.Msg, Severity.Error); }
            if (rsp.Status == ResponseObjectStatusEnum.Success)
            { snackbar.Add(rsp.Msg, Severity.Success); }



            return rsp.Status;
        }
    }
}
