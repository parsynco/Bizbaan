using MudBlazor;
using System.Reflection;

namespace Parsyn.App.Admin.UIServices
{
    public static class BreadCrumbService
    {
        public static IList<BreadcrumbItem>  UrlToCrumbs(this string Path)
        {
            IList<BreadcrumbItem> crumbStructures = [
                new BreadcrumbItem("خانه","/")
                ];
            var path = Path.Split('/');
            var count = 1;

            foreach (var link in path)
            {
                if (link == "") continue;
                count++;
                var lastLink = crumbStructures.Last();
                crumbStructures.Add(new BreadcrumbItem(link,$"{lastLink.Href}/{link}", link != path.Last()));
            }
            return crumbStructures;
        }
        

    }
}
