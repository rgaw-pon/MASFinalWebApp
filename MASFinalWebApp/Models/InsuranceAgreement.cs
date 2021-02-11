using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASFinalWebApp.Models
{
    public enum InsuranceAgreementState { BOUGHT,ACTIVE, CANCELLED, ENDED }
    public class InsuranceAgreement
    {
        [Key]
        [Display(Name=null)]
        public int InsuranceAgreementID { get; set; }
        public int Price { get; set; }
        [Display(Name = "Buy date")]
        public DateTime BuyDate { get; set; }
        public InsuranceAgreementState State { get; set; }
        [Display(Name = "Active from")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateFrom { get; set; }
        [Display(Name = "Active until")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateTo { get; set; }
        [Display(Name = "Additional info")]
        public string AdditionalInfo { get; set; }
        public int? InsuranceID { get; set; }
        public int? InsurancePackageID { get; set; }
        public int ClientID { get; set; }

        public int? InvoiceID { get; set; }

        //public ICollection<Person> Beneficiaries { get; set; }

        public virtual Insurance? Insurance { get; set; }
        [Display(Name = "Insurance package")]
        public virtual InsurancePackage? InsurancePackage { get; set; }

        public virtual Client Client { get; set; }
        public virtual Invoice Invoice { get; set; }


    }
}
