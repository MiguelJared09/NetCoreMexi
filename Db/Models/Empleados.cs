using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Db.Models
{
    public class Empleados
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intIdServicio { get; set; }
        public int intIdUser { get; set; }
        public string varNombreTrabahjo { get; set; }
        public string varDescripcion { get; set; }
        public string varHabilidades { get; set; }
        public string varHorario { get; set; }
        public decimal decSalario { get; set; }
        public int intStatus { get; set; }
        public int intTipoTrabajo { get; set; }
        

    }
    public class EmpleadosView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intIdServicio { get; set; }
        public int intIdUser { get; set; }
        public string varNombreTrabahjo { get; set; }
        public string varDescripcion { get; set; }
        public string varHabilidades { get; set; }
        public string varHorario { get; set; }
        public decimal decSalario { get; set; }
        public string varNombre { get; set; }
        public string varAPatern { get; set; }
        public string varAMatern { get; set; }
        public int intStatus { get; set; }
        public int intTipoTrabajo { get; set; }
    }
    public class postulacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intId { get; set; }
        public int intIdOfertaLab { get; set; }
        public int intIdUser { get; set; }
        public DateTime dtFechaPostulacion { get; set; }

    }
    public class postulacionView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intId { get; set; }
        public int intIdUser { get; set; }
        public string userName { get; set; }
        public string varNombre { get; set; }
        public string varPuesto { get; set; }
        public DateTime dtFechaPostulacion { get; set; }
    }
}


