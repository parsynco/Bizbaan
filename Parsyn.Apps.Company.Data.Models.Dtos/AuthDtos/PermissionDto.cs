﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Data.Models.Dtos.AuthDtos
{
    public class PermissionDto
    {
        public int? Sort {  get; set; }
        public string? Title {  get; set; }
        public string? Url { get; set; }
        public List<PermissionDto>? Childs { get; set; }

    }
}
