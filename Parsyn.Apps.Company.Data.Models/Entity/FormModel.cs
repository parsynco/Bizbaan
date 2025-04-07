using Parsyn.Apps.Company.Data.Models.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Entity.Forms
{
    public class FormModel : BaseModel
    {
        [Description("نوع درخواست")]
        [Required]
        public FormType Type { get; set; } = FormType.Support;
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Phone { get; set; }
        public string? CompanyName { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? IP { get; set; }
    }
    public enum FormType 
    { 
        Support,
        Criticism,//انتقاد
        Suggest,//پیشنهاد
        Complaint//شکایت
    }
}
