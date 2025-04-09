using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiRepasoExamenMPB.Models
{
    [Table("SALA")]
    public class Sala
    {

        [Key]
        [Column("HOSPITAL_COD")]
        public int IdHospital { get; set; }

        [Column("SALA_COD")]
        public int SalaCod { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }

        [Column("NUM_CAMA")]
        public int Camas { get; set; }
    }
}
