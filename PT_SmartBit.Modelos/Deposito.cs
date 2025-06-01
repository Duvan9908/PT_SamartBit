using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_SmartBit.Modelos
{
    public class Deposito
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

        [Required(ErrorMessage = "El campo Monto es requerido.")]
        public int Monto { get; set; }
    }
}
