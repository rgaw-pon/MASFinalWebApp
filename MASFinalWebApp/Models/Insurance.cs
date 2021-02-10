using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASFinalWebApp.Models
{
    public class Insurance
    {
      [Key]
      public int InsuranceID { get; set; }
      public  float InsuranceAmount { get; set; }
      public  string InsuranceRange { get; set; }
      public  string GeneralTermsAndConditions { get; set; }
      public ICollection<InsurancesInPackages> InsurancesInPackages { get; set; }
    }
}
