using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASFinalWebApp.Models
{
    public enum InsuranceAgreementState { ACTIVE, CANCELLED, ENDED }
    public class InsuranceAgreement
    {
        public string InsuranceAgreementID { get; set; }
        public int Price { get; set; }
        public DateTime BuyDate { get; set; }
        public InsuranceAgreementState State { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string AdditionalInfo { get; set; }
        
        

    }
}
