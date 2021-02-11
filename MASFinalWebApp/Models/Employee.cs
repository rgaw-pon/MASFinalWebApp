using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASFinalWebApp.Models
{
    public class Employee : Person
    {
        public int TaxIdentificationNumber { get; set; }
        public DateTime HireDate { get; set; }
        public float Salary { get; set; }
    }
}
