using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Fundamentals.Client.Web.Models
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public int UsuarioIdPropietario { get; set; }
        public int UsuarioIdCreacion { get; set; }
        [Display(Name = "Fecha Creación")]
        public DateTime FechaCreacion { get; set; }
        public int UsuarioIdActualizacion { get; set; }
        [Display(Name = "Fecha Actualización")]
        public DateTime FechaActualizacion { get; set; }

        [Display(Name = "Usuario Actualizacón")]
        public virtual UsuarioViewModel UsuarioActualizacion { get; set; }
        [Display(Name = "Usuario Creación")]
        public virtual UsuarioViewModel UsuarioCreacion { get; set; }
        [Display(Name = "Propietario")]
        public virtual UsuarioViewModel UsuarioPropietario { get; set; }        
    }
}
