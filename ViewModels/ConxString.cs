using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VarDoc.ViewModels
{
    public class ConxString
    {
        public string AllowedHosts { get; set; }

        [Required(ErrorMessage = "Veuillez insérer une configuration valide")]
        public Dictionary<string,string> ConnectionStrings { get; set; }
    }
}
