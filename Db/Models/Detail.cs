using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Db.Models
{
    public class Detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IntidDetalle { get; set; }
        public int IntIdUser { get; set; }
        public string varNombre { get; set; }
        public string varAPatern { get; set; }
        public string varAMatern { get; set; }
        public DateTime dtFechaNac { get; set; }
        public DateTime? dtFechaFund { get; set; }
        public string varCurp { get; set; }
        public string varRfc { get; set; }
        public int intGenero { get; set; }
        public string varCp { get; set; }
        public string varEstado { get; set; }
        public string varMunicipio { get; set; }
        public string varCalle { get; set; }
        public string varColonia { get; set; }
        public string varReferencia { get; set; }
        public string varNoint { get; set; }
        public string varNoExterior { get; set; }
        public string varNoTelefono { get; set; }
        public string varNoTelfR1 { get; set; }
        public string varNoTelfR2 { get; set; }
        public string varRazonSocial { get; set; }
        public int intStatus { get; set; }
        public int intEstudios { get; set; }
        public int intDisponibilidad { get; set; }
        public string descripcion { get; set; }

    }
    public class DetailView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IntidDetalle { get; set; }
        public int IntIdUser { get; set; }
        public string varNombre { get; set; }
        public string varAPatern { get; set; }
        public string varAMatern { get; set; }
        public DateTime dtFechaNac { get; set; }
        public DateTime? dtFechaFund { get; set; }
        public string varCurp { get; set; }
        public string varRfc { get; set; }
        public int intGenero { get; set; }
        public string varCp { get; set; }
        public string varEstado { get; set; }
        public string varMunicipio { get; set; }
        public string varCalle { get; set; }
        public string varColonia { get; set; }
        public string varReferencia { get; set; }
        public string varNoint { get; set; }
        public string varNoExterior { get; set; }
        public string varNoTelefono { get; set; }
        public string varNoTelfR1 { get; set; }
        public string varNoTelfR2 { get; set; }
        public string varRazonSocial { get; set; }
        public int intStatus { get; set; }
        public int intEstudios { get; set; }
        public int intDisponibilidad { get; set; }
        public string descripcion { get; set; }
        public string Email { get; set; }
        
    }


}
