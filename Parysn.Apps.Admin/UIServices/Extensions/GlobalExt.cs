namespace Parysn.Apps.Admin.UIServices.Extensions
{
    public static class GlobalExt
    {
        public static string RmvWhiteSpace(this string str)
        {
            return str.Trim().Replace(" ", "-");
        }
    }
}
