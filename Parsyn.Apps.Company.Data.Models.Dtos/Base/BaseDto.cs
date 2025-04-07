using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Dtos.Base
{
    public class BaseDto
    {
        public int Id { get; set; }
        [NotMapped]
        public DateTime Created_At
        {
            get;

            set;
        } = DateTime.Now;
    }
}
