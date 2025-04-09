using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiRepasoExamenMPB.Models
{
    [Table("PLANTILLA")]
    public class Plantilla
    {
        [Key]
        [Column("HOSPITAL_COD")]
        public int IdHospital { get; set; }

        [Column("SALA_COD")]
        public int SalaCod { get; set; }

        [Column("EMPLEADO_NO")]
        public int IdEmpleado { get; set; }

        [Column("APELLIDO")]
        public string Apellido { get; set; }

        [Column("FUNCION")]
        public string Funcion { get; set; }

        [Column("T")]
        public string Turno { get; set; }

        [Column("SALARIO")]
        public int Salario { get; set; }
    }
}
