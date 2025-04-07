using EasyCompressor;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeTypes;
using Newtonsoft.Json;
using Parsyn.Apps.Company.Data.Models.Dtos;
using Parsyn.Apps.Company.Data.Models.Dtos.Catalog;
using Parsyn.Apps.Company.Data.Models.Dtos.UIDtos;
using Parsyn.Apps.Company.Data.Models.Entity.Config;
using Parsyn.Apps.Company.Data.Models.Entity.User;
using Parsyn.Apps.Company.Service.Utiles.Enums;
using Parsyn.Apps.Company.Service.Utiles.Generators.ImageGenerator;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator;
using Parsyn.Apps.Company.Service.Utiles.Helpers;
using Parsyn.Apps.Company.Services.Interfaces;
using Parsyn.Apps.Company.Services.Interfaces.Config;
using System.Net.Mime;

namespace Parsyn.Apps.Api.Controllers.Admin.Media
{
    [Route("api/admin/fm")]
    [ApiController]
    public class FileManagerController : ControllerBase
    {
        private RespGeneratorSrvc _rspgen;
        private IWebHostEnvironment _env;
        private ImageGeneratorSrvc _generator;
        private IMediaIface _mediaSrvc;
        private string _path = AppDomain.CurrentDomain.BaseDirectory;
        public FileManagerController(IWebHostEnvironment env, IMediaIface mediasrvc)
        {
            _rspgen = new RespGeneratorSrvc();
            _env = env;
            _generator = new ImageGeneratorSrvc();
            _mediaSrvc = mediasrvc;

        }
        [HttpGet("dn/{id}/{size}")]
        public async Task<IActionResult> GetImage(int id, string size = "THUMB")
        {
            try
            {
                Tuple<Stream, FileInfo> result;
                var dto = _mediaSrvc.Get(x => x.Id == id);
                if (dto == null)
                {
                    result = FileMgrHelper.ReadFile(_path);
                }
                var jfsdto = ((MediaModel)dto.Data).JsonFileSize;
                //if()
                //{

                //}
                result = FileMgrHelper.ReadFile(_path, jfsdto, size);
                return File(result.Item1, MimeTypeMap.GetMimeType(result.Item2.Extension));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost("UploadSingle")]
        [Authorize]
        public async Task<IActionResult> UploadSnigle([FromBody] UploadFileDto ufd)
        {
            if (ufd.Content is null || ufd.Content.Length < 1)
            {
                return BadRequest(_rspgen.MapError("فایل یافت نشد"));
            }
            if (ufd.IsImage)
            {
                if (!ValidMimeTypes.ValidTypes().Contains(ufd.FileType))
                {
                    return BadRequest(_rspgen.MapError("فرمت فایل پشتیبانی نمی شود"));
                }
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Media", "FileManager", "Images");
                if (ufd.IsImage)
                {
                    var res = _generator.ResizeToSEOFriendly(ufd.Content, ufd.FileType, path, ufd.AutoResize);
                    return new JsonResult(_rspgen.MapOk(data: res));
                }


            }

            return new JsonResult(_rspgen.MapOk());
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll(int? Cat = 0, string? Title = null)
        {

            var opr = ((List<MediaModel>)_mediaSrvc.GetAll(0, 0).Data).Select(x => x.Dto()).ToArray();

            if (Cat != null && Cat != 0)
                opr = opr.Where(x => x.CatId == Cat).ToArray();

            if (!string.IsNullOrEmpty(Title))
                opr = opr.Where(x => x.MediaTitle.Contains(Title)).ToArray();

            return new JsonResult(opr);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SaveMedia(MediaDto model)
        {

            MediaModel mm = model.Adapt<MediaModel>();
            mm.UrlInSitemap = mm.AltText.Replace(" ", "_");
            var opr = await _mediaSrvc.AddAsync(mm);
            return new JsonResult(opr);
        }
        [HttpPost("delete")]
        [Authorize]
        public async Task<IActionResult> Delete(int Id)
        {
            var opr = await _mediaSrvc.DeleteAsync(x => x.Id == Id);
            return new JsonResult(opr);
        }
    }
}
