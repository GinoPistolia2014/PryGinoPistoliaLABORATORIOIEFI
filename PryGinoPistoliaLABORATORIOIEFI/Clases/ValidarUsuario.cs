using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryGinoPistoliaLABORATORIOIEFI.Clases
{
    internal class ValidarUsuario
    {
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }

        public bool Completada { get; set; }

        public ValidarUsuario(string NombreUsuario, string Contraseña)
        {

            this.NombreUsuario = NombreUsuario;
            this.Contraseña = Contraseña;
            this.Completada = false;

        }
    }
}
