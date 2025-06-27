using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryGinoPistoliaLABORATORIOIEFI.Clases
{
    internal class ValidarDatosUsuario
    {
        public string Usuarios { get; set; }
        public string Contraseña { get; set; }

        public bool Completada { get; set; }

        public ValidarDatosUsuario(string NombreUsuario, string Contraseña)
        {

            this.Usuarios = Usuarios;
            this.Contraseña = Contraseña;
            this.Completada = false;

        }
    }
}
