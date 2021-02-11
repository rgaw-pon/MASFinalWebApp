using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASFinalWebApp.Models
{
    public class SportDiscipline
    {
        [Key]
        public int SportDisciplineID { get; set; }

        public int SportInsuranceID { get; set; }
        public virtual SportInsurance SportInsurance { get; set; }
    }
}
