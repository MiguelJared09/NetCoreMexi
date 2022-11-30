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
    public class OfertasLaboralesVIew
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intIdOfertaLaboral { get; set; }
        public int intIdEmpresa { get; set; }
        public string varPuesto { get; set; }
        public string varDescripcion { get; set; }
        public string varUbicacion { get; set; }
        public decimal decSalario { get; set; }
        public int intEstatus { get; set; }
        public DateTime dtFechaRegistro { get; set; }
        public string Empresa { get; set; }
        public string varRequisitos { get; set; }
        public int IntTipoTrabajo { get; set; }
        public string nombreResponsable { get; set; }
        public int genero { get; set; }

    }
    public class PostulacionOferta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intId { get; set; }
        public int intIdOfertaLab { get; set; }
        public int intIdUser { get; set; }
        public DateTime dtFechaPostulacion { get; set; }
        public int intClaseTrabajador { get; set; }
    }
    public class Postulacionview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intId { get; set; }
        public int intIdOfertaLaboral { get; set; }
        public int intIdUser { get; set; }
        public string UserName { get; set; }
        public string varNombre { get; set; }
        public int Disponibilidad { get; set; }
        public string varPuesto { get; set; }
        public DateTime dtFechaPostulacion { get; set; }
        public string varMunicipio { get; set; }

    }
    public class Servicios
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
    public class SolicitarServicio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int intIdSolicitud { get; set; }
        public int intIdservicio { get; set; }
        public int intIdUsuario { get; set; }
    }
    public class DesactivarOferta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intIdOfertaLaboral { get; set; }
        public int intEstatus { get; set; }
    }
    public class ViewServicios
    {

    }
}
