using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_SmartBit.Modelos
{
    public class Presupuesto
    {
        [Key]
        public int Id { get; set; }

        //Configuración llave foranea
        //Tipo de Gasto
        [Required(ErrorMessage = "El campo Tipo de Gasto es requerido.")]
        public int TipoGastoId { get; set; }
        [ForeignKey("TipoGastoId")]
        public TipoGasto TipoGasto { get; set; }

        [Required(ErrorMessage = "El campo Mes es requerido.")]
        public DateTime Mes { get; set; }

        [Required(ErrorMessage = "El campo Monto es requerido.")]
        public int Monto { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Creación es requerido.")]
        public DateTime FechaCreacion { get; set; }
    }
}
