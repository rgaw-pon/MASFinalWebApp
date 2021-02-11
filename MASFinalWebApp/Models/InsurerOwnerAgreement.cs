using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASFinalWebApp.Models
{
    public class InsurerOwnerAgreement
    {
        public DateTime DateOfIssue { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string AgreementTerms { get; set; }
        public string Details { get; set; }

        public int OwnerId { get; set; }
        public int InsurerId { get; set; }
        public virtual Owner Owner {get;set;}
        public virtual Insurer Insurer { get; set; }

    }
}
