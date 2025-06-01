using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_SmartBit.Modelos
{
    public class GastoDetalle
    {
        [Key]
        public int Id { get; set; }

        //Configuración llave foranea Gasto Encabezado
        [Required(ErrorMessage = "El campo Gasto Encabezado es requerido.")]
        public int GastoEncabezadoId { get; set; }

        [ForeignKey("GastoEncabezadoId")]
        public GastoEncabezado GastoEncabezado { get; set; }

        //Configuración llave foranea Tipo Gasto
        [Required(ErrorMessage = "El campo Tipo de Gasto es requerido.")]
        public int TipoGastoId { get; set; }

        [ForeignKey("TipoGastoId")]
        public TipoGasto TipoGasto { get; set; }

        [Required(ErrorMessage = "El campo Monto es requerido.")]
        public int Monto { get; set; }

    }
}
