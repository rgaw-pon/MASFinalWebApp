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
        public string Name { get; set; }
        [Display(Name = "Insurance amount")]
        [DataType(DataType.Currency)]
        public float InsuranceAmount { get; set; }
        [Display(Name = "Insurance range")]
        public string InsuranceRange { get; set; }
        [Display(Name = "General terms and conditions")]
        [DataType(DataType.MultilineText)]
        public string GeneralTermsAndConditions { get; set; }
        public ICollection<InsurancesInPackages> InsurancesInPackages { get; set; }
        public ICollection<InsuranceAgreement> InsuranceAgreements { get; set; }

    }
}
