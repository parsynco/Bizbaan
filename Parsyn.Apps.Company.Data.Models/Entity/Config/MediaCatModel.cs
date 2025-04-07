using Parsyn.Apps.Company.Data.Models.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.Config
{
    public class MediaCatModel : BaseModel
    {
        public string? Title { get; set; }
        public ICollection<MediaModel>? Medias { get; set; }
    }
}
