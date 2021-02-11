﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASFinalWebApp.Models
{
    public class Insurer
    {
        [Key]
        public int InsurerID { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public string InsurerLicenseNumber { get; set; }
        
    }
}
