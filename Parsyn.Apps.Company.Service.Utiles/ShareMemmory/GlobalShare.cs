using Parsyn.Apps.Company.Data.Models.Dtos.AuthDtos;

namespace Parysn.Apps.Company.Service.Utiles.ShareMemmory
{
    public static class GlobalShare
    {
        private static AuthUserDto User { get; set; } = null;
        public static void SetUser(AuthUserDto authUser)
        {
            User = authUser;
        }
        public static string GetUser()
        {
            return User?.UserName ?? string.Empty;
        }
        public static bool IsAuthenticated()
        {
            return User != null;
        }
        public static string GetToken() {
            return User?.Token ?? null;
        }
    }
}
