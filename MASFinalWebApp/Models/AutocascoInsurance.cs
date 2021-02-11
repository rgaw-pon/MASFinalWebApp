using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASFinalWebApp.Models
{
    public class AutocascoInsurance : Insurance
    {
        public int OwnerID { get; set; }
        public virtual Person Owner { get; set; }

    }
}
