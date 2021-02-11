using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MASFinalWebApp.Models
{
    public class Client : Person
    {
        [Display(Name="Social security number")]
        public string SocialSecurityNumber { get; set; }
        public ICollection<InsuranceAgreement> InsuranceAgreements{ get; set; }
        
    }
}
