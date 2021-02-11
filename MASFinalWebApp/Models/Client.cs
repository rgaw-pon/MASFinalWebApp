using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASFinalWebApp.Models
{
    public class Client : Person
    {
        
        public string SocialSecurityNumber { get; set; }
    }
}
