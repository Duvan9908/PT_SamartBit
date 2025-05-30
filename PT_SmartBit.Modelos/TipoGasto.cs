using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_SmartBit.Modelos
{
    public class TipoGasto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [MaxLength(60, ErrorMessage = "El nombre debe ser de máximo 60 caracteres.")]
        public string Nombre { get; set; }

        [MaxLength(100, ErrorMessage = "La descripcion debe ser de máximo 100 caracteres.")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Activo es requerido.")]
        public bool Activo { get; set; }
    }
}
