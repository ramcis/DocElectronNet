using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VarDoc.Models
{
    public class FicheP
    {
        [Key]
        public int id_fiche { get; set; }

        [Column(TypeName = "nvarchar (250)")]
        [DisplayName("Profession")]
        public string job { get; set; }

        [Column(TypeName = "nvarchar (250)")]
        [DisplayName("Antécédents familiaux")]
        public string anticedent { get; set; }

        [Column(TypeName = "nvarchar (250)")]
        [DisplayName("Antécédents chirurgicaux")]
        public string anticedent_churgical { get; set; }

        [Column(TypeName = "nvarchar (250)")]
        [DisplayName("Antécédents médicaux")]
        public string anticedent_medical { get; set; }

        public Patients Patients { get; set; }
        [ForeignKey("Patients")]
        [DisplayName("Patient")]
        [Required(ErrorMessage = "Champs recquis")]
        public int id_patient { get; set; }

        [Column(TypeName = "nvarchar (250)")]
        [DisplayName("Numéro de Fiche")]
        public string ficheNo { get; set; }
    }
}
