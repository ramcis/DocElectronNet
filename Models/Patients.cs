using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VarDoc.Models
{
    public class Patients
    {
        [Key]
        public int id_patient { get; set; }

        [Column(TypeName = "nvarchar (250)")]
        [DisplayName("Nom")]
        public string nom_patient { get; set; }

        [Column(TypeName = "nvarchar (250)")]
        [DisplayName("Prénom")]
        public string prenom_patient { get; set; }

        [Column(TypeName = "nvarchar (250)")]
        [DisplayName("Père")]
        public string pere_patient { get; set; }

        [Column(TypeName = "nvarchar (250)")]
        [DisplayName("Téléphone")]
        public string tel_patient { get; set; }

        [Column(TypeName = "nnvarchar (250)")]
        [DisplayName("Fiche")]
        public string fiche_patient { get; set; }

        [DisplayName("Date de Naissance")]
       // [Required(ErrorMessage = "Veuillez Remplir tous les champs")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime date_naissance { get; set; }

    }
}
