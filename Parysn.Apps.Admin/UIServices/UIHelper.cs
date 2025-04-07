using MudBlazor;
using Parsyn.Apps.Company.Data.Models.Dtos.UIDtos;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using System.Diagnostics;

namespace Parysn.Apps.Admin.UIServices
{
    public static class UIHelper
    {
        //private static readonly ConfigDto _config;
        public static string BaseUrl { get { return "https://api.bizbaan.com"; } }
        //public static string BaseUrl { get { return "http://localhost:5021"; } }
        static UIHelper()
        {

        }
        public static string ApiUrl()
        {
            //_readFile();
            var url = $"{BaseUrl}/api/admin/";

            return url;
        }
        private static void _readFile()
        {
            try
            {
                //if (_config is not null)
                //{
                //    return;
                //}
                var currentDirectoryPath = Directory.GetCurrentDirectory();

                var pth = Path.Combine(currentDirectoryPath, "Config", "config.json");
                var readfile = File.ReadAllText(pth);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
        public static ResponseObjectStatusEnum HandleResponse(ResponseObject rsp, ISnackbar snackbar)
        {
            if (rsp.Status == ResponseObjectStatusEnum.Error || rsp.Status == ResponseObjectStatusEnum.UnhandeledException)
            { snackbar.Add(rsp.Msg, Severity.Error); }
            if (rsp.Status == ResponseObjectStatusEnum.Success)
            { snackbar.Add(rsp.Msg, Severity.Success); }



            return rsp.Status;
        }
    }
}
