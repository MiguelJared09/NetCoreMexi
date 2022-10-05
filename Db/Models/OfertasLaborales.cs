using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Db.Models
{
    public class OfertasLaborales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IntIdOfertaLaboral { get; set; }
        public int IntIdEmpresa { get; set; }
        public string VarPuesto { get; set; }
        public string VarDescripcion { get; set; }
        public string VarUbicacion { get; set; }
        public decimal DecSalario { get; set; }
        public int IntEstatus { get; set; }
        public DateTime dtFechaRegistro { get; set; }
        public string intTurno { get; set; }
        public string varRequisitos { get; set; }
        public DateTime dtFechaVigencia { get; set; }
        public int IntTipoTrabajo { get; set; }

    }
}
