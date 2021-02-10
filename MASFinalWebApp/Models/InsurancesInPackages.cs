using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MASFinalWebApp.Models
{
    public class InsurancesInPackages
    {
        public int InsuranceID { get; set; }
        public int InsurancePackageID { get; set; }

        public virtual Insurance Insurances { get; set; }
        public virtual InsurancePackage InsurancePackage { get; set; }
    }
}
