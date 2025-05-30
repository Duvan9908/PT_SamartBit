using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_SmartBit.Modelos
{
    public class FondoMonetario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [MaxLength(60, ErrorMessage = "El nombre debe ser de máximo 60 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Tipo es requerido.")]
        public bool Tipo { get; set; }

        [MaxLength(100, ErrorMessage = "La descripción debe ser de máximo 100 caracteres.")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Activo es requerido.")]
        public bool Activo { get; set; }
    }
}
