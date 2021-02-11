using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASFinalWebApp.Models
{
    public enum InsuranceAgreementState { ACTIVE, CANCELLED, ENDED }
    public class InsuranceAgreement
    {
        [Key]
        public string InsuranceAgreementID { get; set; }
        public int Price { get; set; }
        public DateTime BuyDate { get; set; }
        public InsuranceAgreementState State { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string AdditionalInfo { get; set; }

        public int? InsuranceID { get; set; }
        public int? InsurancePackageID { get; set; }
        public int ClientID { get; set; }

        public int InvoiceID { get; set; }
        //public ICollection<Person> Beneficiaries { get; set; }
        
        public virtual Insurance? Insurance { get; set; }
        public virtual InsurancePackage? InsurancePackage { get; set; }
        public virtual Client Client { get; set; }
        public virtual Invoice Invoice { get; set; }
        

    }
}
