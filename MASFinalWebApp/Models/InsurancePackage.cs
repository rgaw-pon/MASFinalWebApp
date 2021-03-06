﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASFinalWebApp.Models
{
    public class InsurancePackage
    {
        [Key]
        public int InsurancePackageID { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public ICollection<InsurancePackage> InsuranceSubpackages { get; set; }
        public ICollection<InsurancesInPackages> InsurancesInPackages { get; set; }
        public ICollection<InsuranceAgreement> InsuranceAgreements { get; set; }
    }
}

