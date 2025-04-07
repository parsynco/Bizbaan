using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Mapster;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Parsyn.Apps.Company.Data.Models.Dtos.AuthDtos;
using Parsyn.Apps.Company.Data.Models.Entity.User;

namespace Parysn.Apps.Admin.UIServices.Auth
{
    public interface IUserObject
    {
        Task<AuthUserDto> GetItem<AuthUserDto>();
        void SetItem(AuthUserDto value);
        void RemoveItem();
        Task<bool> IsAuthenticated();
        Task<string> GetUserName();
        Task<string> GetToken();
        Task<List<PermissionDto>> GetPermissions();
        Task<List<string>> GetPermissionsFlat();
        Task<bool> ExistsPermission(string url);

    }
    public sealed class UserObject(InMemeoryStorage jsRuntime) : IUserObject
    {
        private InMemeoryStorage _jsRuntime = jsRuntime;
        private string _keyName { get; set; } = "_BIZ_USR_";
        private AuthUserDto _user { get; set; }

        public async Task<bool> ExistsPermission(string url)
        {
            var data =await GetItem<AuthUserDto>();
            try
            {
                return data.PermissionUrls.Exists(x => x == url);
            }
            catch {
                return false;
            }
        }

        public async Task<AuthUserDto> GetItem<AuthUserDto>()
        {
            try
            {
                var json =  await _jsRuntime.Read<AuthUserDto>(_keyName);
                return json;
            }
            catch (Exception ex)
            {
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GetItem.txt"), ex.Message + Environment.NewLine + JsonConvert.SerializeObject(ex, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Serialize }));
                throw;
            }
        }

        public async Task<List<PermissionDto>> GetPermissions()
        {
            try
            {
                var data = await GetItem<AuthUserDto>();
                if (data != null)
                    return data.Permissions;

                return [];
            }
            catch (Exception ex)
            {
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GetPermissions.txt"), ex.Message + Environment.NewLine + JsonConvert.SerializeObject(ex, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                throw;
            }
        }

        public async Task<List<string>> GetPermissionsFlat()
        {
            try
            {
                var data = await GetItem<AuthUserDto>();
                if (data != null)
                {
                    return data.PermissionUrls;

                }
                return [];
            }
            catch (Exception ex)
            {
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GetPermissionsFlat.txt"), ex.Message + Environment.NewLine + JsonConvert.SerializeObject(ex, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                throw;
            }
        }

        public async Task<string> GetToken()
        {
            try
            {
                var data =await  GetItem<AuthUserDto>();
                return data != null ? data.Token : string.Empty;
            }
            catch (Exception ex)
            {
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GetToken.txt"), ex.Message + Environment.NewLine + JsonConvert.SerializeObject(ex, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                throw;
            }
        }

        public async Task<string> GetUserName()
        {
            try
            {
                var data =await  GetItem<AuthUserDto>();
                return data != null ? data.UserName : string.Empty;
            }
            catch (Exception ex)
            {
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GetUserName.txt"), ex.Message + Environment.NewLine + JsonConvert.SerializeObject(ex, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                throw;
            }
        }

        public async Task<bool> IsAuthenticated()
        {
            try
            {
                var item =await  GetItem<AuthUserDto>();
                return item != null;
            }
            catch (Exception ex)
            {
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "IsAuthenticated.txt"), ex.Message + Environment.NewLine + JsonConvert.SerializeObject(ex, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                throw;
            }
        }

        public void RemoveItem()
        {
            try
            {
                _jsRuntime.Remove<AuthUserDto>();
            }
            catch (Exception ex)
            {
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RemoveItem.txt"), ex.Message + Environment.NewLine + JsonConvert.SerializeObject(ex, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                throw;
            }
        }

        public void SetItem(AuthUserDto value)
        {
            try
            {
                _jsRuntime.Store<AuthUserDto>( _keyName, value);
            }
            catch (Exception ex)
            {
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SetItem.txt"), ex.Message + Environment.NewLine + JsonConvert.SerializeObject(ex, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
                throw;
            }
        }
    }
}
