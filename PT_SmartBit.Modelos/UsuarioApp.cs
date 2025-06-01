using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PT_SmartBit.Modelos
{
    public class UsuarioApp : IdentityUser
    {
        [Required(ErrorMessage = "El campo Nombres es requerido.")]
        [MaxLength(60)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo Apellidos es requerido.")]
        [MaxLength(80)]
        public string Apellidos { get; set; }

        //[NotMapped] //No se agrega a la BD
        //public string Rol { get; set; }
    }
}
