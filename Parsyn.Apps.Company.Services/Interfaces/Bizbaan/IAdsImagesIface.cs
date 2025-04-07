using Parsyn.Apps.Company.Data.Models.Entity.Bizbaan.Ad;
using Parsyn.Apps.Company.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Interfaces.Bizbaan
{
    public interface IAdsImagesIface : IBaseIface<AdImageModel>
    {
        List<AdImageModel> GetAllInclude();

    }
}
