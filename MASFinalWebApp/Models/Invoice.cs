﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASFinalWebApp.Models
{
    public class Invoice
    {
        [Key]
        public string InvoiceNo { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string BillingInfo { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
