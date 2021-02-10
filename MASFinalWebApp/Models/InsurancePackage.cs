using System;
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
        public string Name { get; set; }
        public ICollection<InsurancesInPackages> InsurancesInPackages { get; set; }
    }
}
