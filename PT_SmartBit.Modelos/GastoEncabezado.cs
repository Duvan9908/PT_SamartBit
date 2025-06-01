using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_SmartBit.Modelos
{
    public class GastoEncabezado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Fecha es requerido.")]
        public DateTime Fecha { get; set; }

        //Configuración llave foranea
        [Required(ErrorMessage = "El campo Fondo Monetario es requerido.")]
        public int FondoMonetarioId { get; set; }

        [ForeignKey("FondoMonetarioId")]
        public FondoMonetario FondoMonetario { get; set; }

        [MaxLength(100, ErrorMessage = "Las observaciones deben ser de máximo 100 caracteres.")]
        public string Observaciones { get; set; }

        [Required(ErrorMessage = "El campo Noombre de Comercio es requerido.")]
        [MaxLength(60, ErrorMessage = "El nombre del comercio debe ser de máximo 60 caracteres.")]
        public string NombreComercio { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Creación es requerido.")]
        [MaxLength(60, ErrorMessage = "El nombre debe ser de máximo 60 caracteres.")]
        public string TipoDocumento { get; set; }

    }
}
