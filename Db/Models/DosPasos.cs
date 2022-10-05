using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Db.Models
{
    public class DosPasos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDosPasos { get; set; }
        public string Email { get; set; }
        public int Codigo { get; set; }
    }
}
